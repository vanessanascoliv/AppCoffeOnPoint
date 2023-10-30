using CoffeOnPoint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace CoffeOnPoint.Data.Mapping {
    public class MapPedido : IEntityTypeConfiguration<Pedido>{
        public void Configure(EntityTypeBuilder<Pedido> builder) {

            builder.ToTable("Pedido");

             builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Cliente)
                .IsRequired()
                .HasColumnName("Cliente")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.NomeProduto)
                .IsRequired()
                .HasColumnName("NomeProduto")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Total)
                .IsRequired()
                .HasColumnName("Total")
                .HasColumnType("DECIMAL(5,2)")
                .HasMaxLength(5);

            builder.Property(p => p.DataPedido)
                 .IsRequired()
                 .HasColumnName("DataPedido")
                 .HasColumnType("SMALLDATETIME")
                 .HasMaxLength(60)
                 .HasDefaultValueSql("GETDATE()");

        
            builder.HasIndex(x => x.Id, "IX_Pedido_Id")
                .IsUnique();


           builder
                .HasMany(x => x.Produtos)
                .WithMany(x => x.Pedidos)
                .UsingEntity<Dictionary<string, object>>(
                     "PedidoProduto",
                     produto => produto
                       .HasOne<Produto>()
                       .WithMany()
                       .HasForeignKey("ProdutoId")
                       .HasConstraintName("FK_PedidosProdutos_ProdutoId"),
                     pedido => pedido
                     .HasOne<Pedido>()
                     .WithMany()
                     .HasForeignKey("PedidoId")
                     .HasConstraintName("FK_PedidoProduto_PedidoId"));


        }
    }
}
