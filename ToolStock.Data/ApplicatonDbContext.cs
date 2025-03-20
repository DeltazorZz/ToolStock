using Microsoft.EntityFrameworkCore;
using ToolStock.Data.Models;

namespace ToolStock.Data
{
    public class ApplicatonDbContext : DbContext
    {
        public ApplicatonDbContext(DbContextOptions<ApplicatonDbContext> options) : base(options){}

        public DbSet<Category> Categories { get; set; }
        public DbSet<BackLog> BackLogs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<ToolAssignment> ToolAssignments { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>()
                .Property(m => m.PricePerUnit)
                .HasPrecision(18, 2); // 18 számjegy, 2 tizedesjegy

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
        }
    }
}
