using Microsoft.EntityFrameworkCore;
using Productry.Bussiness.Models;

namespace Productry.Data.Context
{
    public class ProductryDbContext : DbContext
    {
        public ProductryDbContext(DbContextOptions<ProductryDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductryDbContext).Assembly);
        }
    }

}
