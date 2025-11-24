using AcademiaMagento.Application.AppServices._Base;
using AcademiaMagento.Application.Interfaces._Base;
using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Services._Base;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.AppServices._Base
{
    public abstract class AppServiceBase<TEntity, TViewModel> : IAppServiceBase<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        protected readonly IServiceBase<TEntity> _service;

        protected AppServiceBase(IServiceBase<TEntity> service)
        {
            _service = service;
        }

        protected abstract TViewModel MapToViewModel(TEntity entity);
        protected abstract TEntity MapToEntity(TViewModel viewModel);

        public virtual async Task<TViewModel> GetByIdAsync(long id)
        {
            var entity = await _service.GetByIdAsync(id);
            return entity != null ? MapToViewModel(entity) : null;
        }

        public virtual async Task<IEnumerable<TViewModel>> GetAllAsync()
        {
            var entities = await _service.GetAllAsync();
            return entities.Select(MapToViewModel);
        }

        public virtual async Task AddAsync(TViewModel viewModel)
        {
            var entity = MapToEntity(viewModel);
            await _service.AddAsync(entity);
            await _service.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TViewModel viewModel)
        {
            var entity = MapToEntity(viewModel);
            _service.Update(entity);
            await _service.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(long id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity != null)
            {
                _service.Remove(entity);
                await _service.SaveChangesAsync();
            }
        }
    }
}
