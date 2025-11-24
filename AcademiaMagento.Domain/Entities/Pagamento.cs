using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AcademiaMagento.Domain.Entities
{
    public class Pagamento : BaseEntity
    {
        public long MatriculaId { get; set; }
        public Matricula Matricula { get; set; }

        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; } = DateTime.UtcNow;
        public string Metodo { get; set; }
        public bool Confirmado { get; set; } = false;
    }
}