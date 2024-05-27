using Entities.Entities;
using Infrastructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task AddAsync(User cliente);
        Task<PagedResult<User>> GetUsersWithPhonesPagedAsync(int pageNumber, int pageSize);
        Task<List<User>> GetUsersByIdsAsync(List<int> userIds);
        Task<List<User>> GetUsersByPhoneNumberAsync(string phoneNumber,string ddd);
        Task UpdateAsync(User user);
        Task<User> GetByIdWithPhonesAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task<bool> RemoveAsync(string email);
    }
}
