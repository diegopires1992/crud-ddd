using Domain.Interfaces.Repositories;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextBase _context;

        public UserRepository(ContextBase context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<User>> GetUsersWithPhonesPagedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Users.CountAsync();

            var users = await _context.Users
                .Where(u => u.IsActive)
                .Include(u => u.Phones)
                .OrderBy(u => u.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<User>
            {
                Items = users,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
            };
        }

        public async Task<List<User>> GetUsersByIdsAsync(List<int> userIds)
        {
            var users = await _context.Users
                .Where(u => userIds.Contains(u.Id))
                .ToListAsync();

            return users;
        }
        public async Task<List<User>> GetUsersByPhoneNumberAsync(string phoneNumber, string ddd)
        {
            var users = await _context.Users
                .Include(u => u.Phones)
                .Where(u => u.Phones.Any(p => p.Number == phoneNumber && p.DDD == ddd))
                .ToListAsync();

            return users;
        }
        public async Task UpdateAsync(User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

            if (existingUser != null)
            {
                existingUser.Email = user.Email;
             
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }

        public async Task<User> GetByIdWithPhonesAsync(int id)
        {
            return await _context.Users.Include(u => u.Phones).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<bool> RemoveAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                user.IsActive = false;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }

    }
}
