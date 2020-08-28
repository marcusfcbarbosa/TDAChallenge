using TDA.Domain.ChallengeContext.Entities;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Infra.Context;

namespace TDA.Infra.Repositorys
{
    public class EspecialidadeRepository : BaseRepository<Especialidade>, IEspecialidadeRepository
    {
        private readonly ChallengeContext _context;
        public EspecialidadeRepository(ChallengeContext context) : base(context)
        {
            _context = context;
        }
    }
}