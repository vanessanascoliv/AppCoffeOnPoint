using CoffeOnPoint.Data.Mapping;
using CoffeOnPoint.Models;
using Microsoft.EntityFrameworkCore;


namespace CoffeOnPoint.Data {
    public class CoffeDataContext : DbContext {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        
       

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Password=021968;Persist Security Info=True;User ID=sa;Initial Catalog=CoffeOnPointApp;Data Source=DESKTOP-QM7RBMC");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new MapCategoria());
            modelBuilder.ApplyConfiguration(new MapPedido());
            modelBuilder.ApplyConfiguration(new MapProduto());

        }
    }
}
