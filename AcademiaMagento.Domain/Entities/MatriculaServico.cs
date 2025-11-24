using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Entities
{
    public class MatriculaServico : BaseEntity
    {
        public long MatriculaId { get; set; }
        public Matricula Matricula { get; set; }

        public long ServicoId { get; set; }
        public Servico Servico { get; set; }

        public decimal ValorCobrado { get; set; } // Valor no momento da matrícula
    }
}
