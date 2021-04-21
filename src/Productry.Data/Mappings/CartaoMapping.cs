using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Productry.Bussiness.Models;

namespace Productry.Data.Mappings
{
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("Cartoes");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Titular).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(p => p.Cvv).HasColumnType("CHAR(3)").IsRequired();
            builder.Property(p => p.Numero).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(p => p.DataExpiracao).HasColumnType("VARCHAR(10)").IsRequired();
            builder.Property(p => p.Bandeira).HasColumnType("VARCHAR(30)");

        }
    }
}
