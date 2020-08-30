using FluentValidator;
using FluentValidator.Validation;
using TDA.Shared.Commands;

namespace TDA.Domain.ChallengeContext.Commands.Inputs
{
    public class CriaUserCommand  : Notifiable, ICommand
    {
        
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }

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
             AddNotifications(new ValidationContract()
                 .Requires()
                 .IsNotNull(Role, "Role", "Role é obrigatório")
             );
        }
    }
}