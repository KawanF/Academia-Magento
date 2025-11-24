using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.ViewModels
{
    public class RegistroAcessoViewModel
    {
        public long Id { get; set; }
        public long AlunoId { get; set; }
        public DateTime Hora { get; set; }
        public bool Entrada { get; set; }
    }
}
