using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrageApi.Models;
using TerrageApi.Services;

namespace Terrage.Api.Test
{
    public class UserServiceTests
    {
        [Fact]
        public async Task CreateUserAsync_Should_AddUserToContextAndSaveChanges()
        {
            // Arrange
            var user = new User 
            { 
                ID = 1,
                Username = "Stetu",
                Email = "stetu@stetu.org",
                Password = "testipassu",
                
            };

            var contextSubstitute = Substitute.For<TerrageApiDBContext>(); // Replace with your actual DbContext type
            var userService = new UserService(contextSubstitute); // Create an instance of your UserService

            // Act
            var result = await userService.CreateUserAsync(user);

            // Assert
            await contextSubstitute.Users.Received(1).AddAsync(user); // Verify that AddAsync was called once with the user
            await contextSubstitute.Received(1).SaveChangesAsync(); // Verify that SaveChangesAsync was called once

            Assert.Equal(user, result); // Check that the returned user is the same as the input user
        }
    }
}
