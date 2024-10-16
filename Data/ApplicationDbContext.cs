using EmployeeManagement.Data.Migrations;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EmployeeManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<LeaveApplication>()
                .HasOne(d => d.Status)
                .WithMany()
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascading delete
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<SystemCode> SystemCodes { get; set; }
        public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
    }
}
