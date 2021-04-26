using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Productry.Bussiness.Models;

namespace Productry.Data.Mappings
{
    public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamentos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(c => c.Cartao).WithMany().HasForeignKey(c => c.CartaoId);
        }
    }
}
