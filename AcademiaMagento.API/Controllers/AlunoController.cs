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
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoAppService _alunoAppService;

        public AlunoController(IAlunoAppService alunoAppService)
        {
            _alunoAppService = alunoAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoViewModel>>> GetAll()
        {
            var alunos = await _alunoAppService.GetAllAsync();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoViewModel>> GetById(long id)
        {
            var aluno = await _alunoAppService.GetByIdAsync(id);
            if (aluno == null) return NotFound();
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AlunoViewModel aluno)
        {
            await _alunoAppService.AddAsync(aluno);
            return CreatedAtAction(nameof(GetById), new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, [FromBody] AlunoViewModel aluno)
        {
            if (id != aluno.Id) return BadRequest();
            await _alunoAppService.UpdateAsync(aluno);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _alunoAppService.RemoveAsync(id);
            return NoContent();
        }
    }
}
