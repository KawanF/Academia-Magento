using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.Interfaces
{
    public interface IRegistroAcessoAppService
    {
        Task<bool> RegistrarEntradaAsync(long alunoId);
        Task<bool> RegistrarSaidaAsync(long alunoId);
    }
}
