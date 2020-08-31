using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Medico>> ListaMedicos()
        {
            IQueryable<Medico> query = _context.Medicos.
            Include(me => me.medicoEspecialidades)
            .ThenInclude(e => e.especialidade);
            return await query.ToListAsync();
        }


    }
}