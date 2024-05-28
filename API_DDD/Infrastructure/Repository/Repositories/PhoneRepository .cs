using Domain.Interfaces.Repositories;
using Entities.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly ContextBase _context;

        public PhoneRepository(ContextBase context)
        {
            _context = context;
        }

        public async Task<Phone> GetByIdAsync(int id)
        {
            return await _context.Phones.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Phone phone)
        {
            _context.Phones.Add(phone);
        }

        public async Task UpdateAsync(Phone phone)
        {
            _context.Entry(phone).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var phone = await _context.Phones.FindAsync(id);
            if (phone != null)
            {
                _context.Phones.Remove(phone);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Phone>> GetPhonesByUserIdAsync(int userId)
        {
            return await _context.Phones
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<Phone> GetByPhoneNumberAsync(string ddd, string number)
        {
            return await _context.Phones
                .FirstOrDefaultAsync(p => p.DDD == ddd && p.Number == number);
        }

        public async Task<List<int>> GetUserIdsByPhoneNumberAsync(string phoneNumber)
        {
            var userIds = await _context.Phones
                .Where(p => p.Number == phoneNumber)
                .Select(p => p.UserId)
                .Distinct()
                .ToListAsync();

            return userIds;
        }
    }
}
