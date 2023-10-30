using CoffeOnPoint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace CoffeOnPoint.Data.Mapping {
    public class MapProduto : IEntityTypeConfiguration<Produto> {

        public void Configure(EntityTypeBuilder<Produto> builder) {

            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Imagem)
                .HasColumnName("Image")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnName("Preco")
                .HasColumnType("Decimal(4,2)")
                .HasMaxLength(8);

            builder.Property(x => x.Ingredientes)
                .HasColumnName("Ingredientes")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Quantidade)
               .HasColumnName("Quantidade")
               .HasColumnType("INT");
               



            builder.HasIndex(x => x.Nome, "IX_Produto_Name");


            builder.HasOne(x => x.Categoria)
                  .WithMany(x => x.Produtos)
                  .HasConstraintName("FK_Produto_Categoria")
                  .OnDelete(DeleteBehavior.Cascade);




        }
    }
}