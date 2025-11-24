using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Services._Base;
using AcademiaMagento.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Interfaces.Service
{
    public interface IAlunoService : IServiceBase<Aluno>
    {
        Task<bool> ValidarCPFAsync(string cpf);
        Task<bool> ValidarIdadeMinimaAsync(DateTime dataNascimento);
    }
}
