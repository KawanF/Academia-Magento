using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Interfaces.Service
{
    public interface IServicoService : IServiceBase<Servico>
    {
        Task<IEnumerable<Servico>> GetServicosAtivosAsync();
    }
}
