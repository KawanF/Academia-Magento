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
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaAppService _matriculaAppService;

        public MatriculaController(IMatriculaAppService matriculaAppService)
        {
            _matriculaAppService = matriculaAppService;
        }

        [HttpPost]
        public async Task<ActionResult<MatriculaViewModel>> Create([FromBody] MatriculaCreateViewModel matricula)
        {
            var resultado = await _matriculaAppService.CriarMatriculaAsync(matricula);
            return CreatedAtAction(nameof(GetById), new { id = resultado.Id }, resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatriculaViewModel>> GetById(long id)
        {
            var matricula = await _matriculaAppService.GetByIdAsync(id);
            if (matricula == null) return NotFound();
            return Ok(matricula);
        }
    }
}
