using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Repository._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Interfaces.Repository
{
    public interface IRegistroAcessoRepository : IRepositoryBase<RegistroAcesso>
    {
        Task<IEnumerable<RegistroAcesso>> GetByAlunoIdAsync(long alunoId);
        Task<RegistroAcesso> GetUltimoAcessoAsync(long alunoId);
    }
}
