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
    public class PagamentoRepository : RepositoryBase<Pagamento>, IPagamentoRepository
    {
        public PagamentoRepository(AcademiaContext context) : base(context)
        {
        }

        public async Task<Pagamento> GetByMatriculaIdAsync(long matriculaId)
        {
            return await _dbSet
                .Include(p => p.Matricula)
                .FirstOrDefaultAsync(p => p.MatriculaId == matriculaId);
        }
    }
}
