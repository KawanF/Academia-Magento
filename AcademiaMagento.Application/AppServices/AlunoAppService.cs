using AcademiaMagento.Application.AppServices._Base;
using AcademiaMagento.Application.Interfaces;
using AcademiaMagento.Application.ViewModels;
using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Repository._Base;
using AcademiaMagento.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.AppServices
{
    public class AlunoAppService : AppServiceBase<Aluno, AlunoViewModel>, IAlunoAppService
    {
        private readonly IAlunoService _alunoService;

        public AlunoAppService(IAlunoService alunoService) : base(alunoService)
        {
            _alunoService = alunoService;
        }

        protected override AlunoViewModel MapToViewModel(Aluno entity)
        {
            return new AlunoViewModel
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Email = entity.Email,
                Telefone = entity.Telefone,
                CPF = entity.CPF,
                DataNascimento = entity.DataNascimento,
                Ativo = entity.Ativo
            };
        }

        protected override Aluno MapToEntity(AlunoViewModel viewModel)
        {
            return new Aluno
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Email = viewModel.Email,
                Telefone = viewModel.Telefone,
                CPF = viewModel.CPF,
                DataNascimento = viewModel.DataNascimento,
                Ativo = viewModel.Ativo
            };
        }

        public async Task<AlunoViewModel> GetByEmailAsync(string email)
        {
            var aluno = await ((IAlunoRepository)_alunoService).GetByEmailAsync(email);
            return aluno != null ? MapToViewModel(aluno) : null;
        }
    }
}
