using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Repository._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Interfaces.Repository
{
    public interface IAvaliacaoFisicaRepository : IRepositoryBase<AvaliacaoFisica>
    {
        Task<IEnumerable<AvaliacaoFisica>> GetByAlunoIdAsync(long alunoId);
    }
}
