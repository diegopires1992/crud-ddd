using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using AutoMapper;
using Application.Interfaces;
using Moq;
using WebAPIs.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegistration.Tests
{
    [TestClass]
    public class ValidationTests
    {
        public async Task GetUsers_ReturnsOkResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var controller = new UsersController(userServiceMock.Object, null);

            var pageNumber = 1;
            var pageSize = 10;
            var users = new List<UserDTO>
         {
            new UserDTO { /* Populate with user data */ },
            new UserDTO { /* Populate with user data */ }
             };

            userServiceMock.Setup(service => service.GetPagedUsers(pageNumber, pageSize)).ReturnsAsync(new PagedUserDTO { Users = users });

            // Act
            var result = await controller.GetUsers(pageNumber, pageSize);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<UserDTO>));
            var returnedUsers = (List<UserDTO>)okResult.Value;
            CollectionAssert.AreEqual(users, returnedUsers);
        }

        [TestMethod]
        public async Task AddUsers_ReturnsOkResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var controller = new UsersController(userServiceMock.Object, null);

            var userDto = new UserDTO(); // Mock your user DTO here

            userServiceMock.Setup(service => service.CreateUser(userDto)).ReturnsAsync(1); 

            // Act
            var result = await controller.AddUsers(userDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task GetUserByPhoneNumber_ReturnsOkResult_WhenUserExists()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var controller = new UsersController(userServiceMock.Object, null);

            var phoneNumber = "4599859595";
            var ddd = "84";
            var userDto = new UserDTO
            {
                Name = "diego",
                Email = "diego@example.com",
                Phones = new List<PhoneDTO>
        {
            new PhoneDTO { DDD = "84", Number = "4599859595", Type = (Entities.Enums.PhoneType)1 },
            new PhoneDTO { DDD = "84", Number = "4599859595", Type = (Entities.Enums.PhoneType)1 }
        }
            };

            userServiceMock.Setup(service => service.GetUserByPhoneNumber(phoneNumber, ddd)).ReturnsAsync(new List<UserDTO> { userDto });

            // Act
            var result = await controller.GetUserByPhoneNumber(phoneNumber, ddd);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result.Result;          
           
        }

        [TestMethod]
        public async Task UpdateUserEmail_ReturnsOkResult()
        {
            var userServiceMock = new Mock<IUserService>();
            var controller = new UsersController(userServiceMock.Object, null);

            var userId = 1;
            var updateEmailDto = new UpdateEmailDTO { NewEmail = "new@example.com" };

            userServiceMock.Setup(service => service.UpdateUserEmail(userId, updateEmailDto.NewEmail)).Returns(Task.CompletedTask);

            var result = await controller.UpdateUserEmail(userId, updateEmailDto);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task UpdateUserPhone_ReturnsOkResult()
        {
            var userServiceMock = new Mock<IUserService>();
            var controller = new UsersController(userServiceMock.Object, null);

            var userId = 1;
            var idPhone = 1;
            var updatePhoneDto = new UpdatePhoneDTO { ddd = "123", NewPhone = "987654321" };

            userServiceMock.Setup(service => service.UpdateUserPhone(userId, idPhone, It.IsAny<PhoneDTO>())).Returns(Task.CompletedTask);


            var result = await controller.UpdateUserPhone(userId, idPhone, updatePhoneDto);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteUserByEmail_ReturnsOkResult()
        {
            var userServiceMock = new Mock<IUserService>();
            var controller = new UsersController(userServiceMock.Object, null);

            var email = "user@example.com";

            userServiceMock.Setup(service => service.DeleteUserByEmail(email)).ReturnsAsync(true);

            var result = await controller.DeleteUserByEmail(email);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

    }


}

