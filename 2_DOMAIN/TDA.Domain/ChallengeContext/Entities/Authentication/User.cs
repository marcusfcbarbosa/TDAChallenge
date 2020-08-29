using TDA.Shared.Entities;

namespace TDA.Domain.ChallengeContext.Entities.Authentication
{
    public class User : Entity
    {
        public User(string userName, string passWord, string role)
        {
            UserName = userName;
            PassWord = passWord;
            Role = role;
        }
        private  User(){}
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public string Role { get; private set; }

    }
}