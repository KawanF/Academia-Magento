using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Interfaces.Service
{
    public interface IPagamentoService : IServiceBase<Pagamento>
    {
        Task<bool> ProcessarPagamentoAsync(long matriculaId, string metodo);
        Task<bool> ConfirmarPagamentoAsync(long pagamentoId);
    }
}
