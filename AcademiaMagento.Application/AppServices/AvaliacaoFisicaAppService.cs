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
    public class AvaliacaoFisicaAppService : IAvaliacaoFisicaAppService
    {
        private readonly IAvaliacaoFisicaService _avaliacaoService;

        public AvaliacaoFisicaAppService(IAvaliacaoFisicaService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        public async Task<bool> AgendarAvaliacaoAsync(AvaliacaoFisicaViewModel viewModel)
        {
            return await _avaliacaoService.AgendarAvaliacaoAsync(
                viewModel.AlunoId,
                viewModel.DataAgendada,
                viewModel.Observacoes
            );
        }
    }
}
