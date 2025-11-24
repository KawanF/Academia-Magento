using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Repository._Base;
using AcademiaMagento.Infra.Data;
using AcademiaMagento.Infra.Data.EntityFramework.Context;
using AcademiaMagento.Infra.Data.Repository._Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Infra.Repository
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(AcademiaContext context) : base(context)
        {
        }

        public async Task<Aluno> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Aluno> GetByCPFAsync(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.CPF == cpf);
        }
    }
}
