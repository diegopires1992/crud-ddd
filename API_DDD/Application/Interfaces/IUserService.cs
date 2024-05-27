using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUser(UserDTO userDTO);
        Task<PagedUserDTO> GetPagedUsers(int pageNumber, int pageSize);
        Task<List<UserDTO>> GetUserByPhoneNumber(string phoneNumber,string ddd);
        Task UpdateUserEmail(int userId, string newEmail);
        Task UpdateUserPhone(int userId, int idPhone, PhoneDTO updatePhoneDTO);
        Task<bool> DeleteUserByEmail(string email);
    }
}
