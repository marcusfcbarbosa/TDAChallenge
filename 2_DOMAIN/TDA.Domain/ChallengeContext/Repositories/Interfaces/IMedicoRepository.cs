using System.Collections.Generic;
using System.Threading.Tasks;
using TDA.Domain.ChallengeContext.Entities;

namespace TDA.Domain.ChallengeContext.Repositories.Interfaces
{
    public interface IMedicoRepository : IBaseRepository<Medico>
    {
        Task<IEnumerable<Medico>> ListaMedicos();

        

    }
}