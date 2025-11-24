using AcademiaMagento.Application.AppServices;
using AcademiaMagento.Application.Interfaces;
using AcademiaMagento.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaMagento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoAppService _pagamentoAppService;

        public PagamentoController(IPagamentoAppService pagamentoAppService)
        {
            _pagamentoAppService = pagamentoAppService;
        }

        [HttpPost]
        public async Task<ActionResult> ProcessarPagamento([FromBody] PagamentoCreateViewModel pagamento)
        {
            var sucesso = await _pagamentoAppService.ProcessarPagamentoAsync(pagamento);
            if (!sucesso) return BadRequest("Erro ao processar pagamento");
            return Ok(new { message = "Pagamento processado com sucesso" });
        }

        [HttpPost("{id}/confirmar")]
        public async Task<ActionResult> ConfirmarPagamento(long id)
        {
            var sucesso = await _pagamentoAppService.ConfirmarPagamentoAsync(id);
            if (!sucesso) return NotFound();
            return Ok(new { message = "Pagamento confirmado" });
        }
    }
}
