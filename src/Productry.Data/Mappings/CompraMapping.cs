using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Productry.Bussiness.Models;

namespace Productry.Data.Mappings
{
    public class CompraMapping : IEntityTypeConfiguration<Compra>
    {

        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compras");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.DataCompra).HasColumnType("Date");


            // 1 : N => Produto-Compra
            builder.HasOne(p => p.Produto).WithMany(c => c.Compras).HasForeignKey(p=> p.ProdutoId);

            // 1 : N => Compra-Cartao
            builder.HasOne(c => c.Cartao).WithMany().HasForeignKey(c => c.CartaoId);

        }
    }
}
