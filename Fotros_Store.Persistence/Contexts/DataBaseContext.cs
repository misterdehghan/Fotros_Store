using Fotros_Store.Application.Interfaces.Contexts;
using Fotros_Store.Common.Roles;
using Fotros_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fotros_Store.Persistence.Contexts
{
    public class DataBaseContext:DbContext ,IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) :base (options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role>  Roles { get; set; }
        public DbSet<UserInRole>   UserInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });
        }
    }
}
