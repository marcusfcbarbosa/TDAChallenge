using System.Threading.Tasks;
using TDA.Domain.ChallengeContext.Entities.Authentication;

namespace TDA.Domain.ChallengeContext.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
         
         Task<User> retornaPorNomeSenha(string  nome, string senha);
    }
}