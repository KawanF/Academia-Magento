using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Repository;
using AcademiaMagento.Domain.Interfaces.Repository._Base;
using AcademiaMagento.Domain.Interfaces.Service;
using AcademiaMagento.Domain.Interfaces.Services;
using AcademiaMagento.Domain.Services._Base;
using System;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Services
{
    public class AlunoService : ServiceBase<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository repo) : base(repo)
        {
            _alunoRepository = repo;
        }

        public async Task<bool> ValidarCPFAsync(string cpf)
        {
            // Validação básica de CPF
            if (string.IsNullOrWhiteSpace(cpf)) return false;

            cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

            if (cpf.Length != 11) return false;

            // Verifica se já existe aluno com este CPF
            var alunoExistente = await _alunoRepository.GetByCPFAsync(cpf);
            return alunoExistente == null; // Retorna true se CPF estiver disponível
        }

        public Task<bool> ValidarIdadeMinimaAsync(DateTime dataNascimento)
        {
            var idade = DateTime.UtcNow.Year - dataNascimento.Year;
            if (DateTime.UtcNow < dataNascimento.AddYears(idade)) idade--;

            return Task.FromResult(idade >= 16); // Idade mínima 16 anos
        }
    }
}