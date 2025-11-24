using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Entities
{
    public class Matricula : BaseEntity
    {
        public long AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public bool Ativo { get; set; } = true;
        public DateTime DataMatricula { get; set; } = DateTime.UtcNow;
        public decimal ValorTotal { get; set; }

        // Navegação
        public ICollection<MatriculaServico> MatriculaServicos { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}
