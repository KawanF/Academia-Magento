using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Repository;
using AcademiaMagento.Domain.Interfaces.Service;
using AcademiaMagento.Domain.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Services
{
    public class ServicoService : ServiceBase<Servico>, IServicoService
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoService(IServicoRepository repo) : base(repo)
        {
            _servicoRepository = repo;
        }

        public async Task<IEnumerable<Servico>> GetServicosAtivosAsync()
        {
            return await _servicoRepository.GetActivosAsync();
        }
    }
}
