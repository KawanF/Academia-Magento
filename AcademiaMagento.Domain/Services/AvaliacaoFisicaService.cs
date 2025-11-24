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
    public class AvaliacaoFisicaService : ServiceBase<AvaliacaoFisica>, IAvaliacaoFisicaService
    {
        private readonly IAvaliacaoFisicaRepository _avaliacaoRepository;

        public AvaliacaoFisicaService(IAvaliacaoFisicaRepository repo) : base(repo)
        {
            _avaliacaoRepository = repo;
        }

        public async Task<bool> AgendarAvaliacaoAsync(long alunoId, DateTime dataAgendada, string observacoes)
        {
            if (dataAgendada <= DateTime.UtcNow) return false;

            var avaliacao = new AvaliacaoFisica
            {
                AlunoId = alunoId,
                DataAgendada = dataAgendada,
                Observacoes = observacoes
            };

            await _avaliacaoRepository.AddAsync(avaliacao);
            await _avaliacaoRepository.SaveChangesAsync();
            return true;
        }
    }
}
