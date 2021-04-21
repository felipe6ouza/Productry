using Microsoft.EntityFrameworkCore;
using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Models;
using Productry.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Productry.Data.Repository
{
    public class ComprasRepository : Repository<Compra>, IComprasRepository
    {
        public ComprasRepository(ProductryDbContext productryDbContext) : base (productryDbContext) 
        {
        }

        public override async Task<Compra> ObterPorId(int id)
        {
            return await Db.Compras
                .AsNoTracking()
                .Include(c => c.Cartao)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Compra>> ObterTodos()
        {
            return await Db.Compras
               .AsNoTracking()
               .Include(c => c.Cartao)
               .ToListAsync();
        }
    }
}
