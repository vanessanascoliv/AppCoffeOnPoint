using CoffeOnPoint.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoffeOnPoint.Data.Mapping {
    public class MapCategoria : IEntityTypeConfiguration<Categoria> {
        public void Configure(EntityTypeBuilder<Categoria> builder) {
            
            builder.ToTable("Categoria");

            builder.HasKey(x => x.Id);

            builder.Property( x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(X => X.Icone)
                .HasColumnName("Icone")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            builder.HasIndex(x => x.Nome, "IX_Categoria_Name")
                .IsUnique();

              




        }
    }
}
