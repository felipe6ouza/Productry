using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Productry.API.ViewModels;
using Productry.Bussiness.Interfaces;
using Productry.Bussiness.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Productry.API.Controllers
{
    [Route("api/compras")]
    public class ComprasController : MainController
    {

            private readonly ICompraService _compraService;
            private readonly IEstoqueService _estoqueService;
            private readonly IMapper _mapper;

        public ComprasController(ICompraService compraService, IEstoqueService estoqueService, IMapper mapper)
        {
            _compraService = compraService;
            _estoqueService = estoqueService;
            _mapper = mapper;
        }

       [HttpPost]
        public async Task<ActionResult> ComprarProduto(CompraViewModel compraViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    success = false,
                    message = "Os valores informados não são válidos!",
                    erros = ModelState.Values.SelectMany(e => e.Errors).Select(m => m.ErrorMessage)
                });

           var compraRealizada = await _compraService.RealizarCompra(_mapper.Map<Compra>(compraViewModel));

            if(!compraRealizada)
            {
                return StatusCode(412, new { sucess = false, message = "Ocorreu um erro desconhecido."});
            }



            return Ok(new { sucess = true, message= "Compra Realizada com sucesso."});
        }
    }
}
