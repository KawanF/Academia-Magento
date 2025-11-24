using AcademiaMagento.Application.Interfaces._Base;
using AcademiaMagento.Application.ViewModels;
using AcademiaMagento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.Interfaces
{
    public interface IServicoAppService : IAppServiceBase<Servico, ServicoViewModel>
    {
        Task<IEnumerable<ServicoViewModel>> GetServicosAtivosAsync();
    }
}
