using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContainer
{
    public class DefineUserRoleContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DefineUserRoleContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<DefineUserRoleContext>(null);
        }
    }
}