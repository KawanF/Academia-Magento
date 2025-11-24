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
    public class AcessoController : ControllerBase
    {
        private readonly IRegistroAcessoAppService _acessoAppService;

        public AcessoController(IRegistroAcessoAppService acessoAppService)
        {
            _acessoAppService = acessoAppService;
        }

        [HttpPost("entrada")]
        public async Task<ActionResult> RegistrarEntrada([FromBody] AcessoRequestViewModel request)
        {
            var sucesso = await _acessoAppService.RegistrarEntradaAsync(request.AlunoId);
            if (!sucesso) return BadRequest("Acesso negado. Matrícula inativa.");
            return Ok(new { message = "Entrada registrada com sucesso" });
        }

        [HttpPost("saida")]
        public async Task<ActionResult> RegistrarSaida([FromBody] AcessoRequestViewModel request)
        {
            var sucesso = await _acessoAppService.RegistrarSaidaAsync(request.AlunoId);
            if (!sucesso) return BadRequest("Erro ao registrar saída");
            return Ok(new { message = "Saída registrada com sucesso" });
        }
    }
}

