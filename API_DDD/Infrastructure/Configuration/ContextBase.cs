using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class ContextBase: DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Phone> Phones { get; set; }
    }
}

