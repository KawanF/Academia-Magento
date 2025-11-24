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
    public class MatriculaRepository : RepositoryBase<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(AcademiaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Matricula>> GetByAlunoIdAsync(long alunoId)
        {
            return await _dbSet
                .Include(m => m.MatriculaServicos)
                    .ThenInclude(ms => ms.Servico)
                .Where(m => m.AlunoId == alunoId)
                .ToListAsync();
        }

        public async Task<Matricula> GetMatriculaAtivaByAlunoIdAsync(long alunoId)
        {
            return await _dbSet
                .Include(m => m.MatriculaServicos)
                    .ThenInclude(ms => ms.Servico)
                .FirstOrDefaultAsync(m => m.AlunoId == alunoId && m.Ativo);
        }
    }
}
