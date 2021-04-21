using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Productry.API.ViewModels;
using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Productry.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        public ProdutosController(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> ObterProdutosCadastrados()
        {
            var listaProdutos = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
            return Ok(new
            {
                success = true,
                data = listaProdutos
            });
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> ObterProduto(int id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));

            if (produto == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Produto não encontrado!",

                });
            }

            return Ok(new
            {
                success = true,
                data = produto
            });
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> RemoverProduto(int id)
        {

            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));

            if (produto == null)
                return NotFound(new
                {
                    success = false,
                    message = "Produto não encontrado!",

                });

            await _produtoRepository.Remover(id);

            return Ok(new
            {
                success = true,
                message = "Produto Removido!",
            });
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarProduto(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                    {
                        success = false,
                        message = "Os valores informados não são válidos!",
                        data = ModelState.Values.SelectMany(e => e.Errors).Select(m => m.ErrorMessage)
                    });
                    
            await _produtoRepository.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return Ok(new
            {
                success = true,
                message = "Produto Cadastrado!",
                data = produtoViewModel
            });


        }
    }
}
