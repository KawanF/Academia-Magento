using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.Interfaces._Base
{
    public interface IAppServiceBase<TEntity, TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        Task<TViewModel> GetByIdAsync(long id);
        Task<IEnumerable<TViewModel>> GetAllAsync();
        Task AddAsync(TViewModel viewModel);
        Task UpdateAsync(TViewModel viewModel);
        Task RemoveAsync(long id);
    }
}
