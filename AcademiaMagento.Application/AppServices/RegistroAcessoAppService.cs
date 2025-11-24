using AcademiaMagento.Application.Interfaces;
using AcademiaMagento.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.AppServices
{
    public class RegistroAcessoAppService : IRegistroAcessoAppService
    {
        private readonly IRegistroAcessoService _acessoService;

        public RegistroAcessoAppService(IRegistroAcessoService acessoService)
        {
            _acessoService = acessoService;
        }

        public async Task<bool> RegistrarEntradaAsync(long alunoId)
        {
            return await _acessoService.RegistrarEntradaAsync(alunoId);
        }

        public async Task<bool> RegistrarSaidaAsync(long alunoId)
        {
            return await _acessoService.RegistrarSaidaAsync(alunoId);
        }
    }
}
