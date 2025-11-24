using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Repository;
using AcademiaMagento.Infra.Data.EntityFramework.Context;
using AcademiaMagento.Infra.Data.Repository._Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Infra.Data.EntityFramework.Repository
{
    public class ServicoRepository : RepositoryBase<Servico>, IServicoRepository
    {
        public ServicoRepository(AcademiaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Servico>> GetActivosAsync()
        {
            return await _dbSet.Where(s => s.Ativo).ToListAsync();
        }
    }
}
