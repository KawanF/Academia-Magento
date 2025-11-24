using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Entities
{
    public class Servico : BaseEntity
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; } = true;

        // Navegação
        public ICollection<MatriculaServico> MatriculaServicos { get; set; }
    }
}