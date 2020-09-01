using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDA.Domain.ChallengeContext.Entities;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;

namespace TDA.Test.Repositorys
{
    public class FakeMedicoRepository : IMedicoRepository
    {
        public void Create(Medico entity)
        {

        }

        public bool Delete(Medico entity)
        {
            return true;
        }

        public void Delete(int id)
        {
         
        }

        public void Edit(Medico entity)
        {
            
        }

        public IEnumerable<Medico> Filter()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medico> Filter(Func<Medico, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Medico GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Medico>> ListaMedicos()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            
        }
    }
}