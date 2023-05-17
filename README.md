# RamandProject
Here's a sample project outline that demonstrates generating a JWT, retrieving users after authentication, and sending the first user in the queue using RabbitMQ:

# How to use the database

To create the `database tables` and `stored procedures` located in the `Migration folder` using `Visual Studio's Package Manager Console`, you can execute the following command:
```
Update-Database
```
The two stored procedures named `GetUsersProcedure` and `GetFirstUser` are as follows:
```tsql
CREATE PROCEDURE GetUsersProcedure
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Username, Email
    FROM AspNetUsers;
END

CREATE PROCEDURE GetFirstUser
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Username, Email
    FROM AspNetUsers;
END
```

# SeedData

After the first run, Seed data [UserSeedInitializer](https://github.com/aligholipour/RamandProject/blob/master/Ramand/Ramand.Infrastructure/Persistence/UserSeedInitializer.cs) will be added automatically.

```csharp
var users = new[]
{
    new User { UserName = "admin@example.com", Email = "admin@example.com", Password = "Ramand123" },
    new User { UserName = "customer1@example.com", Email = "customer1@example.com", Password = "Ramand123" },
    new User { UserName = "customer2@example.com", Email = "customer2@example.com", Password = "Ramand123" },
};
```

# Swagger
To use authorization in Swagger, simply include the `generated JWT` after calling the `Login method`, and the `"Bearer"` prefix will be added automatically.

You can also use the following values for login:
```
UserName = "admin@example.com"
Password = "Ramand123"
```
# RabbitMQ
To use RabbitMQ in `Docker`, you can use the following command:
```
docker run --rm -it --hostname my-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:latest
```


