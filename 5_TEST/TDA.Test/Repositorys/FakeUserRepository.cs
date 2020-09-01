using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TDA.Domain.ChallengeContext.Entities.Authentication;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;

namespace TDA.Test.Repositorys
{
    public class FakeUserRepository : IUserRepository
    {
        public void Create(User entity)
        {
            
        }

        public bool Delete(User entity)
        {
            return true;
        }

        public void Delete(int id)
        {
            
        }

        public void Edit(User entity)
        {
            
        }

        public IEnumerable<User> Filter()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Filter(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> retornaPorNomeSenha(string nome, string senha)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
         
        }
    }
}