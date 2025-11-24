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
    public class ServicoController : ControllerBase
    {
        private readonly IServicoAppService _servicoAppService;

        public ServicoController(IServicoAppService servicoAppService)
        {
            _servicoAppService = servicoAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicoViewModel>>> GetAll()
        {
            var servicos = await _servicoAppService.GetAllAsync();
            return Ok(servicos);
        }

        [HttpGet("ativos")]
        public async Task<ActionResult<IEnumerable<ServicoViewModel>>> GetAtivos()
        {
            var servicos = await _servicoAppService.GetServicosAtivosAsync();
            return Ok(servicos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoViewModel>> GetById(long id)
        {
            var servico = await _servicoAppService.GetByIdAsync(id);
            if (servico == null) return NotFound();
            return Ok(servico);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ServicoViewModel servico)
        {
            await _servicoAppService.AddAsync(servico);
            return CreatedAtAction(nameof(GetById), new { id = servico.Id }, servico);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, [FromBody] ServicoViewModel servico)
        {
            if (id != servico.Id) return BadRequest();
            await _servicoAppService.UpdateAsync(servico);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _servicoAppService.RemoveAsync(id);
            return NoContent();
        }
    }
}
