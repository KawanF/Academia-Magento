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
            var matricula = new Matricula
            {
                AlunoId = alunoId,
                ValorTotal = 0,
                Ativo = false
            };

            matricula.MatriculaServicos = new List<MatriculaServico>();

            foreach (var servicoId in servicosIds)
            {
                var servico = await _servicoRepository.GetByIdAsync(servicoId);

                matricula.MatriculaServicos.Add(new MatriculaServico
                {
                    ServicoId = servico.Id,
                    ValorCobrado = servico.Valor
                });

                matricula.ValorTotal += servico.Valor;
            }

            await _matriculaRepository.AddAsync(matricula);
            await _matriculaRepository.SaveChangesAsync();

            return matricula;
        }

        public async Task<bool> VerificarMatriculaAtivaAsync(long alunoId)
        {
            var matricula = await _matriculaRepository.GetMatriculaAtivaByAlunoIdAsync(alunoId);
            return matricula != null;
        }

        public async Task<Matricula> GetByIdAsync(long id)
        {
            return await _matriculaRepository.GetByIdWithServicosAsync(id);
        }


    }
}
