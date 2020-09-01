using System;
using System.Collections.Generic;
using TDA.Domain.ChallengeContext.Entities;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;

namespace TDA.Test.Repositorys
{
    public class FakeEspecialidadeRepository : IEspecialidadeRepository
    {
        public void Create(Especialidade entity)
        {
            
        }

        public bool Delete(Especialidade entity)
        {
         return true;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Especialidade entity)
        {
            
        }

        public IEnumerable<Especialidade> Filter()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Especialidade> Filter(Func<Especialidade, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Especialidade GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
           
        }
    }
}