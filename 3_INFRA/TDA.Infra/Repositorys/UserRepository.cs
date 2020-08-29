using TDA.Domain.ChallengeContext.Entities.Authentication;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Infra.Context;

namespace TDA.Infra.Repositorys
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ChallengeContext _context;
        public UserRepository(ChallengeContext context) : base(context)
        {
            _context = context;
        }
    }
}