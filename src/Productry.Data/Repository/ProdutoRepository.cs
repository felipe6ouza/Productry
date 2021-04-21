using Microsoft.EntityFrameworkCore;
using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Models;
using Productry.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Productry.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProductryDbContext productryDbContext) : base(productryDbContext) { }

        public async Task<Compra> ObterUltimaCompra(int ProdutoId)
        {
            return await Db.Compras.AsNoTracking().Where(p => p.ProdutoId == ProdutoId).OrderBy(p => p.DataCompra).FirstOrDefaultAsync();
        }
    }
}
