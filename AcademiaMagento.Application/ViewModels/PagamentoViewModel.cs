using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Application.ViewModels
{
    public class PagamentoViewModel
    {
        public long Id { get; set; }
        public long MatriculaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public string Metodo { get; set; }
        public bool Confirmado { get; set; }
    }
}
