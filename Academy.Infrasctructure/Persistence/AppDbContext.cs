using Academy.Core.Entities;
using Academy.Infrasctructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Infrasctructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.ApplyConfiguration(new InstructorConfiguration());


            modelBuilder.ApplyConfiguration(new SportConfiguration());


            modelBuilder.ApplyConfiguration(new StudentConfiguration());


            modelBuilder.Entity<Student>()
                .Ignore(s => s.PaymentHistory);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.PaymentHistory)
                .WithOne(p => p.Student)
                .HasForeignKey(p => p.StudentId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
