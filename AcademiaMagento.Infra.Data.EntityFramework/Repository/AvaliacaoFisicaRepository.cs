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
    public class AvaliacaoFisicaRepository : RepositoryBase<AvaliacaoFisica>, IAvaliacaoFisicaRepository
    {
        public AvaliacaoFisicaRepository(AcademiaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AvaliacaoFisica>> GetByAlunoIdAsync(long alunoId)
        {
            return await _dbSet
                .Where(a => a.AlunoId == alunoId)
                .OrderByDescending(a => a.DataAgendada)
                .ToListAsync();
        }
    }
}
