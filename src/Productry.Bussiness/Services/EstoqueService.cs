using Productry.Bussiness.Interfaces;
using System.Threading.Tasks;

namespace Productry.Services.Services
{
    public class EstoqueService : IEstoqueService
    {

        private readonly IProdutoRepository _produtoRepository;

        public EstoqueService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<bool> AlterarEstoque(int produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null)
                return false;

            produto.AlterarEstoque(quantidade);

            if(!produto.IsValid)
            {
                return false;
            }
           
           return await _produtoRepository.Atualizar(produto);

        }

    }
}
