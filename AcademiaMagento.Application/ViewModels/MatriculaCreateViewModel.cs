using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.ViewModels
{
    public class MatriculaCreateViewModel
    {
        public long AlunoId { get; set; }
        public List<long> ServicosIds { get; set; }
    }
}
