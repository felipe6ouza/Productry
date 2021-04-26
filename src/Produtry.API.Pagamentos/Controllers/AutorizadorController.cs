using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Productry.Bussiness.Models;
using Productry.Services.Interfaces;
using Produtry.API.Pagamentos.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Produtry.API.Pagamentos.Controllers
{
    [ApiController]
    [Route("api/pagamento/")]
    public class AutorizadorController : ControllerBase
    {

        private readonly IAutorizarCompraService _autorizarCompraService;
        private readonly IMapper _mapper;

        public AutorizadorController(IAutorizarCompraService autorizarCompraService, IMapper mapper)
        {
            _autorizarCompraService = autorizarCompraService;
            _mapper = mapper;
        }

        [HttpPost("compras")]
        public async Task<ActionResult> AutorizarPagamento(PagamentoViewModel pagamentoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    sucess = false,
                    valor = pagamentoViewModel.Valor,
                    estado = "REJEITADA"
                });


            var IsAuthorized = await _autorizarCompraService.AutorizarCompra(_mapper.Map<Pagamento>(pagamentoViewModel));
            
            if(!IsAuthorized)
                return BadRequest (new
                {
                    sucess = false,
                    valor = pagamentoViewModel.Valor,
                    estado = "REJEITADA"
                });

            return Ok
                (new
                {
                   sucess = true,
                   valor = pagamentoViewModel.Valor,
                   estado = "APROVADA"
                });

        }
    }
}
