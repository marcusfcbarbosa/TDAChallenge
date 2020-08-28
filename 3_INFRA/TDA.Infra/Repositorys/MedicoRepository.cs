using TDA.Domain.ChallengeContext.Entities;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Infra.Context;

namespace TDA.Infra.Repositorys
{
    public class MedicoRepository : BaseRepository<Medico>, IMedicoRepository
    {
        private readonly ChallengeContext _context;
        public MedicoRepository(ChallengeContext context) : base(context)
        {
            _context = context;
        }
    }
}