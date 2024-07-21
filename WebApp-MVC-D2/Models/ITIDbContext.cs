using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebApp_MVC_D2.Models
{
    public class ITIDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AB9QMA0;Database=ITI-MVC;Trusted_Connection=True;Encrypt=False;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Dept)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DeptId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Instructor>()
                .HasOne(c => c.Crs)
                .WithMany(i => i.Instructors)
                .HasForeignKey(i => i.CrsId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Trainee>()
            .HasOne(t => t.Dept)
            .WithMany(d => d.Trainees)
            .HasForeignKey(t => t.DeptId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Dept)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DeptId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CrsResult>()
                .HasOne(cr => cr.Crs)
                .WithMany(c => c.CrsResults)
                .HasForeignKey(cr => cr.CrsId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CrsResult>()
                .HasOne(cr => cr.Trainee)
                .WithMany(t => t.CrsResults)
                .HasForeignKey(cr => cr.TraineeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
