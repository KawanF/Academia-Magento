using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Repository;
using AcademiaMagento.Domain.Interfaces.Service;
using AcademiaMagento.Domain.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Services
{
    public class RegistroAcessoService : ServiceBase<RegistroAcesso>, IRegistroAcessoService
    {
        private readonly IRegistroAcessoRepository _acessoRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public RegistroAcessoService(
            IRegistroAcessoRepository acessoRepo,
            IMatriculaRepository matriculaRepo) : base(acessoRepo)
        {
            _acessoRepository = acessoRepo;
            _matriculaRepository = matriculaRepo;
        }

        public async Task<bool> RegistrarEntradaAsync(long alunoId)
        {
            if (!await ValidarAcessoAsync(alunoId)) return false;

            var registro = new RegistroAcesso
            {
                AlunoId = alunoId,
                Entrada = true
            };

            await _acessoRepository.AddAsync(registro);
            await _acessoRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RegistrarSaidaAsync(long alunoId)
        {
            var registro = new RegistroAcesso
            {
                AlunoId = alunoId,
                Entrada = false
            };

            await _acessoRepository.AddAsync(registro);
            await _acessoRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ValidarAcessoAsync(long alunoId)
        {
            var matriculaAtiva = await _matriculaRepository.GetMatriculaAtivaByAlunoIdAsync(alunoId);
            return matriculaAtiva != null;
        }
    }
}
