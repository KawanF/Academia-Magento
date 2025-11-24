using AcademiaMagento.Domain.Entities;
using AcademiaMagento.Domain.Interfaces.Services._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaMagento.Domain.Interfaces.Service
{
    public interface IAvaliacaoFisicaService : IServiceBase<AvaliacaoFisica>
    {
        Task<bool> AgendarAvaliacaoAsync(long alunoId, DateTime dataAgendada, string observacoes);
    }
}
