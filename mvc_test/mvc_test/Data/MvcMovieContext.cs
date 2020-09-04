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

        public DbSet<Movie> Movie { get; set; }
        public DbSet<user> user { get; set; }
        public DbSet<student> student { get; set; }
        public DbSet<teacher> teacher { get; set; }
        public object UsersTable { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>().ToTable("user");
            modelBuilder.Entity<student>().ToTable("student");
            modelBuilder.Entity<teacher>().ToTable("teacher");
        }
    }
}