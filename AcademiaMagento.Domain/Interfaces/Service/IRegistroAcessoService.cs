using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Interfaces.Service
{
    public interface IRegistroAcessoService : IServiceBase<RegistroAcesso>
    {
        Task<bool> RegistrarEntradaAsync(long alunoId);
        Task<bool> RegistrarSaidaAsync(long alunoId);
        Task<bool> ValidarAcessoAsync(long alunoId);
    }
}
