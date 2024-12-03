using DesafioBackEnd.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.DAL.Data
{
    public abstract class AbstractDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasOne(i => i.IdPedidoNavigation)
                .WithMany(p => p.Itens)
                .HasForeignKey(i => i.NumeroPedido);
            });
        }
    }
}
