using Microsoft.EntityFrameworkCore;
using My_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<User> Tb_User { get; set; }
        public virtual DbSet<Roles> Tb_Roles { get; set; }
        public virtual DbSet<Employee> Tb_Employees { get; set; }

    }
}
