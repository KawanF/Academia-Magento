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
    public class RegistroAcessoRepository : RepositoryBase<RegistroAcesso>, IRegistroAcessoRepository
    {
        public RegistroAcessoRepository(AcademiaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RegistroAcesso>> GetByAlunoIdAsync(long alunoId)
        {
            return await _dbSet
                .Where(r => r.AlunoId == alunoId)
                .OrderByDescending(r => r.Hora)
                .ToListAsync();
        }

        public async Task<RegistroAcesso> GetUltimoAcessoAsync(long alunoId)
        {
            return await _dbSet
                .Where(r => r.AlunoId == alunoId)
                .OrderByDescending(r => r.Hora)
                .FirstOrDefaultAsync();
        }
    }
}
