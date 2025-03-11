using Microsoft.EntityFrameworkCore;
using ToolStock.Models;
namespace ToolStock.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Material> Materials { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<InventoryMovement> InventoryMovements { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ToolAssignment> ToolAssignments { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationItem> QuotationItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.TotalAmount)
                .HasColumnType("decimal(18, 2)");  // Tedd be a kívánt típusú decimal típus beállítást

            modelBuilder.Entity<InvoiceItem>()
                .Property(ii => ii.TotalPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<InvoiceItem>()
                .Property(ii => ii.UnitPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Material>()
                .Property(m => m.PricePerUnit)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Quotation>()
                .Property(q => q.TotalAmount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<QuotationItem>()
                .Property(qi => qi.TotalPrice)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<QuotationItem>()
                .Property(qi => qi.UnitPrice)
                .HasColumnType("decimal(18, 2)");
        }


    }
}
