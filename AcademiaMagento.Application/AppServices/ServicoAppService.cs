using AcademiaMagento.Application.AppServices._Base;
using AcademiaMagento.Application.Interfaces;
using AcademiaMagento.Application.ViewModels;
using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.AppServices
{
    public class ServicoAppService : AppServiceBase<Servico, ServicoViewModel>, IServicoAppService
    {
        private readonly IServicoService _servicoService;

        public ServicoAppService(IServicoService servicoService) : base(servicoService)
        {
            _servicoService = servicoService;
        }

        protected override ServicoViewModel MapToViewModel(Servico entity)
        {
            return new ServicoViewModel
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Valor = entity.Valor,
                Descricao = entity.Descricao,
                Ativo = entity.Ativo
            };
        }

        protected override Servico MapToEntity(ServicoViewModel viewModel)
        {
            return new Servico
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Valor = viewModel.Valor,
                Descricao = viewModel.Descricao,
                Ativo = viewModel.Ativo
            };
        }

        public async Task<IEnumerable<ServicoViewModel>> GetServicosAtivosAsync()
        {
            var servicos = await _servicoService.GetServicosAtivosAsync();
            return servicos.Select(MapToViewModel);
        }
    }

}
