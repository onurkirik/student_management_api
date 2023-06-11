using Microsoft.EntityFrameworkCore;
using student_management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace student_management.Persistance.Context
{
    public class ApplicationDbContext : DbContext
    {
        public const string ConnectionString = "StudentManagement";
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<Gender> Gender { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
