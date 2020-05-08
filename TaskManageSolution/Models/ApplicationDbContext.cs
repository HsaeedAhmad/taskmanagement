using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Models;

namespace TaskManageSolution.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<TaskManagement.Models.Users> Users { get; set; }
        public DbSet<TaskManagement.Models.UserTask> UserTask { get; set; }
        public DbSet<TaskManagement.Models.UserRole> UserRole { get; set; }
    }
   
}
