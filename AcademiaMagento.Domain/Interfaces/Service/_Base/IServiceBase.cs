using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Interfaces.Services._Base
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task SaveChangesAsync();
    }
}
