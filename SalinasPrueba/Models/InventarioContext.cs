using Microsoft.EntityFrameworkCore;

namespace SalinasPrueba.Models
{
    public class InventarioContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<ProductoFactura> ProductoFacturas { get; set; }

        public InventarioContext(DbContextOptions<InventarioContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoFactura>()
                .HasKey(pf => new { pf.ProductoId, pf.FacturaId });

            modelBuilder.Entity<ProductoFactura>()
              .HasOne(pf => pf.Producto)
              .WithMany(p => p.Productofacturas)
              .HasForeignKey(pf => pf.ProductId);

            modelBuilder.Entity<ProductoFactura>()
                .HasOne(pf => pf.Factura)
                .WithMany(f => f.Productofacturas)
                .HasForeignKey(pf => pf.FacturaId);
        }
    }
}
