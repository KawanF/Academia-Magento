using AcademiaMagento.Domain.Interfaces.Repository._Base;
using AcademiaMagento.Domain.Interfaces.Services._Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Services._Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
    }
}
