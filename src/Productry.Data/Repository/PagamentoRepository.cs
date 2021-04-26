using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Models;
using Productry.Data.Context;

namespace Productry.Data.Repository
{
    public class PagamentoRepository : Repository<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(ProductryDbContext productryDbContext) : base(productryDbContext) { }
        
    }
}
