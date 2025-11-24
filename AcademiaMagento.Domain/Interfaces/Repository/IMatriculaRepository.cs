using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Repository._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Interfaces.Repository
{
    public interface IMatriculaRepository : IRepositoryBase<Matricula>
    {
        Task<IEnumerable<Matricula>> GetByAlunoIdAsync(long alunoId);
        Task<Matricula> GetMatriculaAtivaByAlunoIdAsync(long alunoId);
    }
}
