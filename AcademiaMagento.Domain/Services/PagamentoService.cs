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
    public class PagamentoService : ServiceBase<Pagamento>, IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public PagamentoService(
            IPagamentoRepository pagamentoRepo,
            IMatriculaRepository matriculaRepo) : base(pagamentoRepo)
        {
            _pagamentoRepository = pagamentoRepo;
            _matriculaRepository = matriculaRepo;
        }

        public async Task<bool> ProcessarPagamentoAsync(long matriculaId, string metodo)
        {
            var matricula = await _matriculaRepository.GetByIdAsync(matriculaId);
            if (matricula == null) return false;

            var pagamentoExistente = await _pagamentoRepository.GetByMatriculaIdAsync(matriculaId);
            if (pagamentoExistente != null) return false;

            var pagamento = new Pagamento
            {
                MatriculaId = matriculaId,
                Valor = matricula.ValorTotal,
                Metodo = metodo,
                Confirmado = false
            };

            await _pagamentoRepository.AddAsync(pagamento);
            await _pagamentoRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ConfirmarPagamentoAsync(long pagamentoId)
        {
            var pagamento = await _pagamentoRepository.GetByIdAsync(pagamentoId);
            if (pagamento == null) return false;

            pagamento.Confirmado = true;
            _pagamentoRepository.Update(pagamento);

            // Ativa a matrícula
            var matricula = await _matriculaRepository.GetByIdAsync(pagamento.MatriculaId);
            matricula.Ativo = true;
            _matriculaRepository.Update(matricula);

            await _pagamentoRepository.SaveChangesAsync();
            return true;
        }
    }
}
