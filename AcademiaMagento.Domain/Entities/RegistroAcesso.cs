using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AcademiaMagento.Domain.Entities
{
    public class RegistroAcesso : BaseEntity
    {
        public long AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public DateTime Hora { get; set; } = DateTime.UtcNow;
        public bool Entrada { get; set; } // true = entrada, false = saida
    }
}

