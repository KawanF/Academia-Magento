using AcademiaMagento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.Interfaces
{
    public interface IPagamentoAppService
    {
        Task<bool> ProcessarPagamentoAsync(PagamentoCreateViewModel viewModel);
        Task<bool> ConfirmarPagamentoAsync(long pagamentoId);
    }
}
