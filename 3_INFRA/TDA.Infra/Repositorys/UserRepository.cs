using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User> retornaPorNomeSenha(string nome, string senha)
        {
            User user = await _context.Users.Where(x => x.UserName == nome && x.PassWord == senha).FirstOrDefaultAsync();
            return user;
        }
    }
}