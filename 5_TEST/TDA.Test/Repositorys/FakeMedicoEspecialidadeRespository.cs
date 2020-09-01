using System;
using System.Collections.Generic;
using TDA.Domain.ChallengeContext.Entities;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;

namespace TDA.Test.Repositorys
{
    public class FakeMedicoEspecialidadeRespository : IMedicoEspecialidadeRespository
    {
        public void Create(MedicoEspecialidade entity)
        {
            
        }

        public bool Delete(MedicoEspecialidade entity)
        {
            return true;
        }

        public void Delete(int id)
        {
         
        }

        public void Edit(MedicoEspecialidade entity)
        {
         
        }

        public IEnumerable<MedicoEspecialidade> Filter()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicoEspecialidade> Filter(Func<MedicoEspecialidade, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public MedicoEspecialidade GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            
        }
    }
}