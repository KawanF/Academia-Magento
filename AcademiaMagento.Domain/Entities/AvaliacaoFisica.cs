using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AcademiaMagento.Domain.Entities
{
    public class AvaliacaoFisica : BaseEntity
    {
        public long AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public DateTime DataAgendada { get; set; }
        public string Observacoes { get; set; }
    }
}
