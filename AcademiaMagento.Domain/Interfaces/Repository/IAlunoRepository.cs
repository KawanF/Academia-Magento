using AcademiaMagento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Interfaces.Repository._Base
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {
        Task<Aluno> GetByEmailAsync(string email);
        Task<Aluno> GetByCPFAsync(string cpf);
    }
}
