using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; } = true;

        // Navegação
        public ICollection<Matricula> Matriculas { get; set; }
        public ICollection<AvaliacaoFisica> AvaliacoesFisicas { get; set; }
        public ICollection<RegistroAcesso> RegistrosAcesso { get; set; }
    }
}
