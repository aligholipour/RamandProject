using FluentAssertions;
using NSubstitute;
using Ramand.Application.Dtos;
using Ramand.Domain.Contracts;
using Ramand.Infrastructure.Repositories;
using RamandTest.Common;

namespace RamandTest
{
    public class UserTest : PersistTest
    {
        [Fact]
        public async Task ShouldReturnListOfUsers2()
        {
            var dapperContext = Substitute.For<IDapperContext>();
            var repository = new UserRepository(dapperContext);

            dapperContext.CreateConnection().Returns(DbConnection);

            var users = new List<UsersDto>
            {
                new UsersDto{ Username = "admin@example.com", Email = "admin@example.com" },
                new UsersDto{ Username = "customer1@example.com", Email = "customer1@example.com" },
                new UsersDto{ Username = "customer2@example.com", Email = "customer2@example.com" }
            };

            var actual = await repository.GetUsers();

            var expected = users;

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task ShouldReturnFirstOfUsers()
        {
            var dapperContext = Substitute.For<IDapperContext>();
            var repository = new UserRepository(dapperContext);

            dapperContext.CreateConnection().Returns(DbConnection);

            var users = new UsersDto { Username = "admin@example.com", Email = "admin@example.com" };

            var actual = await repository.GetFirstUser();

            var expected = users;

            actual.Should().BeEquivalentTo(expected);
        }
    }
}