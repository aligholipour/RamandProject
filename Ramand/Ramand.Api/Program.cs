using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Ramand.Api.Extensions;
using Ramand.Application.Contracts;
using Ramand.Application.UseCases.UserIntraction;
using Ramand.Domain.Contracts;
using Ramand.Infrastructure.Common;
using Ramand.Infrastructure.Persistence;
using Ramand.Infrastructure.Repositories;
using Ramand.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomIdentity();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddApiVersioningConfigs();

builder.Services.AddSqlServer<AppDbContext>(builder.Configuration.GetConnectionString("SqlConnection"));

builder.Services.AddSwaggerConfigs();

builder.Services.AddSingleton<IDapperContext, DapperContext>();

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();

builder.Services.Configure<RabbitMQConfigurations>(builder.Configuration.GetSection("RabbitMQ"));

var app = builder.Build();

var apiVersionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    await UserSeedInitializer.Initialize(scope.ServiceProvider);
}


app.MapControllers();

app.Run();
