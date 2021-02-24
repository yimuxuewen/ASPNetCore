using GrpcDemo.Protos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcDemo.Repository
{
    public class APPDbContext: DbContext
    {
        public APPDbContext(DbContextOptions<APPDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Employee>().ToTable("Employees");
        }
    }
}
