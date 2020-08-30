using TDA.Domain.ChallengeContext.Entities.Authentication;
using TDA.Domain.ChallengeContext.ViewModel;

namespace TDA.Domain.ChallengeContext.Adapter
{
    public static class UserAdapter
    {
        
        public static UserViewModel DomainToViewModel(User user){

            return new UserViewModel{
                identifyer =  user.identifyer,
                UserName = user.UserName
            };
            
        } 
    }
}