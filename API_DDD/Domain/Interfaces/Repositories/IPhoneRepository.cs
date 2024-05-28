using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IPhoneRepository
    {
        Task<Phone> GetByIdAsync(int id);
        Task AddAsync(Phone phone);
        Task UpdateAsync(Phone phone);
        Task DeleteAsync(int id);
        Task<List<Phone>> GetPhonesByUserIdAsync(int userId);
        Task<Phone> GetByPhoneNumberAsync(string ddd, string number);
        Task<List<int>> GetUserIdsByPhoneNumberAsync(string phoneNumber);
        Task SaveChangesAsync();
    }
}
