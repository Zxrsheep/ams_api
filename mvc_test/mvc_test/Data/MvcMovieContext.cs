using Microsoft.EntityFrameworkCore;
using mvc_test.Models;

namespace mvc_test.Data
{
    public class mvc_testContext : DbContext
    {
        public mvc_testContext(DbContextOptions<mvc_testContext> options)
            : base(options)
        {
        }

        
        public DbSet<user> user { get; set; }
        public DbSet<student> student { get; set; }
        public DbSet<teacher> teacher { get; set; }
        public DbSet<course> course { get; set; }
        public DbSet<section> section { get; set; }
        public DbSet<time_slot> time_slot { get; set; }
        public DbSet<classroom_info> classroom_info { get; set; }
        public DbSet<register> register { get; set; }
        public DbSet<leave_application> leave_application { get; set; }
        public DbSet<supplementary_signature> supplementary_signature { get; set; }
        public object UsersTable { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>().ToTable("user");
            modelBuilder.Entity<student>().ToTable("student");
            modelBuilder.Entity<teacher>().ToTable("teacher");
            modelBuilder.Entity<course>().ToTable("course");
            modelBuilder.Entity<section>().ToTable("section");
            modelBuilder.Entity<time_slot>().ToTable("time_slot");
            modelBuilder.Entity<classroom_info>().ToTable("classroom_info");
            modelBuilder.Entity<register>().ToTable("register");
            modelBuilder.Entity<leave_application>().ToTable("leave_application");
            modelBuilder.Entity<supplementary_signature>().ToTable("supplementary_signature");
        }
    }
}