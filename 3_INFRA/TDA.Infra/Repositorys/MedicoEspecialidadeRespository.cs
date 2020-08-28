using TDA.Domain.ChallengeContext.Entities;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Infra.Context;

namespace TDA.Infra.Repositorys
{
    public class MedicoEspecialidadeRespository : BaseRepository<MedicoEspecialidade>, IMedicoEspecialidadeRespository
    {
         private readonly ChallengeContext _context;
        public MedicoEspecialidadeRespository(ChallengeContext context) : base(context)
        {
            _context = context;
        }
    }
}