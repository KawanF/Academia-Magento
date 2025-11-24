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
    public class PagamentoAppService : IPagamentoAppService
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoAppService(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        public async Task<bool> ProcessarPagamentoAsync(PagamentoCreateViewModel viewModel)
        {
            return await _pagamentoService.ProcessarPagamentoAsync(
                viewModel.MatriculaId,
                viewModel.Metodo
            );
        }

        public async Task<bool> ConfirmarPagamentoAsync(long pagamentoId)
        {
            return await _pagamentoService.ConfirmarPagamentoAsync(pagamentoId);
        }
    }
}
