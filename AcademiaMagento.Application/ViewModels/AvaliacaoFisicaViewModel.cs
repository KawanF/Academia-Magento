using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.ViewModels
{
    public class AvaliacaoFisicaViewModel
    {
        public long Id { get; set; }
        public long AlunoId { get; set; }
        public DateTime DataAgendada { get; set; }
        public string Observacoes { get; set; }
    }
}
