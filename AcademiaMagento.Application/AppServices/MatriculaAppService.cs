using AcademiaMagento.Application.Interfaces;
using AcademiaMagento.Application.ViewModels;
using AcademiaMagento.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.AppServices
{
    public class MatriculaAppService : IMatriculaAppService
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaAppService(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        public async Task<MatriculaViewModel> CriarMatriculaAsync(MatriculaCreateViewModel viewModel)
        {
            var matricula = await _matriculaService.CriarMatriculaAsync(
                viewModel.AlunoId,
                viewModel.ServicosIds
            );

            return new MatriculaViewModel
            {
                Id = matricula.Id,
                AlunoId = matricula.AlunoId,
                ValorTotal = matricula.ValorTotal,
                DataMatricula = matricula.DataMatricula,
                Ativo = matricula.Ativo
            };
        }

        public async Task<MatriculaViewModel> GetByIdAsync(long id)
        {
            var matricula = await _matriculaService.GetByIdAsync(id);
            if (matricula == null) return null;

            return new MatriculaViewModel
            {
                Id = matricula.Id,
                AlunoId = matricula.AlunoId,
                ValorTotal = matricula.ValorTotal,
                DataMatricula = matricula.DataMatricula,
                Ativo = matricula.Ativo,
                ServicosIds = matricula.MatriculaServicos?
                                    .Select(ms => ms.ServicoId)
                                    .ToList()
            };
        }

    }
}
