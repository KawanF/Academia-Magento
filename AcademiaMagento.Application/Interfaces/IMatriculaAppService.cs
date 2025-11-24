using AcademiaMagento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.Interfaces
{
    public interface IMatriculaAppService
    {
        Task<MatriculaViewModel> CriarMatriculaAsync(MatriculaCreateViewModel viewModel);
        Task<MatriculaViewModel> GetByIdAsync(long id);
    }
}
