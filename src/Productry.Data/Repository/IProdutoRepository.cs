using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Models;
using Productry.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productry.Data.Repository
{
   public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProductryDbContext productryDbContext) : base(productryDbContext) { }
     
    }
}
