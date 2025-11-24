using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.ViewModels
{
    public class MatriculaViewModel
    {
        public long Id { get; set; }
        public long AlunoId { get; set; }
        public List<long> ServicosIds { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataMatricula { get; set; }
        public bool Ativo { get; set; }
    }
}
