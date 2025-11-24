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
    public class MatriculaService : ServiceBase<Matricula>, IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IServicoRepository _servicoRepository;

        public MatriculaService(
            IMatriculaRepository matriculaRepo,
            IServicoRepository servicoRepo) : base(matriculaRepo)
        {
            _matriculaRepository = matriculaRepo;
            _servicoRepository = servicoRepo;
        }

        public async Task<Matricula> CriarMatriculaAsync(long alunoId, List<long> servicosIds)
        {
            var servicos = new List<Servico>();
            foreach (var id in servicosIds)
            {
                var servico = await _servicoRepository.GetByIdAsync(id);
                if (servico != null && servico.Ativo)
                    servicos.Add(servico);
            }

            var valorTotal = servicos.Sum(s => s.Valor);

            var matricula = new Matricula
            {
                AlunoId = alunoId,
                ValorTotal = valorTotal,
                Ativo = false, // Ativo só após pagamento confirmado
                MatriculaServicos = servicos.Select(s => new MatriculaServico
                {
                    ServicoId = s.Id,
                    ValorCobrado = s.Valor
                }).ToList()
            };

            await _matriculaRepository.AddAsync(matricula);
            await _matriculaRepository.SaveChangesAsync();
            return matricula;
        }

        public async Task<bool> VerificarMatriculaAtivaAsync(long alunoId)
        {
            var matricula = await _matriculaRepository.GetMatriculaAtivaByAlunoIdAsync(alunoId);
            return matricula != null;
        }
    }
}
