using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPhoneService
    {
        Task<int> AddPhoneAsync(int userId, PhoneDTO phoneDTO);
        Task UpdatePhoneAsync(int id, PhoneDTO phoneDTO);
        Task DeletePhoneAsync(int id);
        Task<PhoneDTO> GetPhoneByIdAsync(int id);
        Task<PhoneDTO> GetPhoneByNumberAsync(string ddd, string number);
        Task<List<PhoneDTO>> GetPhonesByUserIdAsync(int userId);
    }
}
