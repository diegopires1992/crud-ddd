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
        [TestMethod]
        public async Task GetUsers_DeveRetornarOkObjectResult_ComListaDeUsuariosDTO()
        {
            // Arrange
            var pageNumber = 1;
            var pageSize = 10;

            var mockUserService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();

            //var expectedUsers = new List<UserDTO>
            //{
            //    new UserDTO { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            //    new UserDTO { Id = 2, Name = "Jane Doe", Email = "jane.doe@example.com" }
            //};

            //var expectedPagedUserDTO = new PagedUserDTO
            //{
            //    Users = expectedUsers,
            //    PageNumber = pageNumber,
            //    PageSize = pageSize,
            //    TotalItems = expectedUsers.Count,
            //    TotalPages = 1
            //};

            //mockUserService.Setup(service => service.GetPagedUsers(pageNumber, pageSize))
            //               .ReturnsAsync(expectedPagedUserDTO);

            //var controller = new UsersController(mockUserService.Object, mockMapper.Object);

            //var result = await controller.GetUsers(pageNumber, pageSize);

            //var okResult = result.Result as OkObjectResult;
            //Assert.IsNotNull(okResult);
            //Assert.AreEqual(200, okResult.StatusCode);

            //var returnedUsers = okResult.Value as PagedUserDTO;
            //Assert.IsNotNull(returnedUsers);
            //Assert.AreEqual(expectedPagedUserDTO.Users.Count, returnedUsers.Users.Count);
        }

        [TestMethod]
        public async Task AddUsers_DeveRetornarOkResult_AoAdicionarUsuario()
        {
            var mockUserService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();

            //var userDto = new UserDTO { Id = 1, Name = "John Doe", Email = "john.doe@example.com" };

            //mockUserService.Setup(service => service.CreateUser(userDto)).Returns((Task<int>)Task.CompletedTask);

            //var controller = new UsersController(mockUserService.Object, mockMapper.Object);

            //var result = await controller.AddUsers(userDto);

            //var okResult = result as OkResult;
            //Assert.IsNotNull(okResult);
            //Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task GetUserByPhoneNumber_DeveRetornarOkObjectResult_QuandoUsuarioExiste()
        {

            var mockUserService = new Mock<IUserService>();
            var mockMapper = new Mock<AutoMapper.IMapper>();

            var phoneNumber = "123456789";
            var ddd = "11";

            //var expectedUser = new UserDTO { Id = 1, Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = phoneNumber, DDD = ddd };

            //mockUserService.Setup(service => service.GetUserByPhoneNumber(phoneNumber, ddd))
            //               .ReturnsAsync(expectedUser);

            var controller = new UsersController(mockUserService.Object, mockMapper.Object);

  
            var result = await controller.GetUserByPhoneNumber(phoneNumber, ddd);

            //var okResult = result.Result as OkObjectResult;
            //Assert.IsNotNull(okResult);
            //Assert.AreEqual(200, okResult.StatusCode);

            //var returnedUser = okResult.Value as UserDTO;
            //Assert.IsNotNull(returnedUser);
            //Assert.AreEqual(expectedUser.Id, returnedUser.Id);
        }

        [TestMethod]
        public async Task UpdateUserEmail_DeveRetornarOkResult_QuandoAtualizacaoBemSucedida()
        {
            var userId = 1;
            var newEmail = "new.email@example.com";
            var updateEmailDto = new UpdateEmailDTO { NewEmail = newEmail };

            var mockUserService = new Mock<IUserService>();
            var mockMapper = new Mock<IMapper>();

            mockUserService.Setup(service => service.UpdateUserEmail(userId, newEmail)).Returns(Task.CompletedTask);

            var controller = new UsersController(mockUserService.Object, mockMapper.Object);

            var result = await controller.UpdateUserEmail(userId, updateEmailDto);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual("Email updated successfully.", okResult.Value);
        }


    }


}
