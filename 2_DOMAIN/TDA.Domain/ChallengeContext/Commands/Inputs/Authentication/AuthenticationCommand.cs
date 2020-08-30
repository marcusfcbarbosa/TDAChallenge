using FluentValidator;
using FluentValidator.Validation;
using TDA.Shared.Commands;

namespace TDA.Domain.ChallengeContext.Commands.Inputs.Authentication
{
    public class AuthenticationCommand : Notifiable, ICommand
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public void Validate()
        {
            AddNotifications(new ValidationContract()
                 .Requires()
                 .IsNotNull(UserName, "UserName", "UserName é obrigatório")
             );
             AddNotifications(new ValidationContract()
                 .Requires()
                 .IsNotNull(PassWord, "PassWord", "PassWord é obrigatório")
             );
        }
    }
}