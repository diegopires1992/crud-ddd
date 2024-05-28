using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace WebAPIs.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [Produces("application/json")]

    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, AutoMapper.IMapper @object)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsers([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            
            var clientes = await _userService.GetPagedUsers(pageNumber, pageSize);

            return Ok(clientes);
            
        }

        [HttpPost]
        public async Task<ActionResult> AddUsers(UserDTO customerDTO)
        {
            await _userService.CreateUser(customerDTO);

            return Ok();
        }

        [HttpGet("SearchByPhoneNumber")]
        public async Task<ActionResult<UserDTO>> GetUserByPhoneNumber([FromQuery] string phoneNumber, [FromQuery] string ddd)
        {
            var user = await _userService.GetUserByPhoneNumber(phoneNumber, ddd);
            if (user == null)
                return Ok(new UserDTO[0]);

            return Ok(user);
        }

        [HttpPut("{userId}/update-email")]
        public async Task<ActionResult> UpdateUserEmail(int userId, [FromBody] UpdateEmailDTO updateEmailDto)
        {
            try
            {
                await _userService.UpdateUserEmail(userId, updateEmailDto.NewEmail);
                return Ok("Email updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{userId}/update-phone/{idPhone}")]
        public async Task<ActionResult> UpdateUserPhone(int userId, int idPhone, [FromBody] UpdatePhoneDTO updatePhoneDto)
        {
            try
            {
                var phoneDto = new PhoneDTO
                {
                    DDD = updatePhoneDto.ddd,
                    Number = updatePhoneDto.NewPhone,
                };

                await _userService.UpdateUserPhone(userId, idPhone, phoneDto);
                return Ok("Phone number updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-by-email")]
        public async Task<ActionResult> DeleteUserByEmail([FromQuery] string email)
        {
            try
            {
                var userDeleted = await _userService.DeleteUserByEmail(email);

                if (userDeleted)
                {
                    return Ok("User deleted successfully.");
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
