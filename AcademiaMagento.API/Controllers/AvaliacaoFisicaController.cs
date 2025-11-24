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
    public class AvaliacaoFisicaController : ControllerBase
    {
        private readonly IAvaliacaoFisicaAppService _avaliacaoAppService;

        public AvaliacaoFisicaController(IAvaliacaoFisicaAppService avaliacaoAppService)
        {
            _avaliacaoAppService = avaliacaoAppService;
        }

        [HttpPost]
        public async Task<ActionResult> Agendar([FromBody] AvaliacaoFisicaViewModel avaliacao)
        {
            var sucesso = await _avaliacaoAppService.AgendarAvaliacaoAsync(avaliacao);
            if (!sucesso) return BadRequest("Erro ao agendar avaliação");
            return Ok(new { message = "Avaliação agendada com sucesso" });
        }
    }
}
