using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Interfaces.Service
{
    public interface IMatriculaService : IServiceBase<Matricula>
    {
        Task<Matricula> CriarMatriculaAsync(long alunoId, List<long> servicosIds);
        Task<bool> VerificarMatriculaAtivaAsync(long alunoId);
    }
}
