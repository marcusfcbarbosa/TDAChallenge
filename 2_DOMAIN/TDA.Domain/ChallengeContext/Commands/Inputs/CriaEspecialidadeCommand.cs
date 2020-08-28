using FluentValidator;
using FluentValidator.Validation;
using TDA.Shared.Commands;

namespace TDA.Domain.ChallengeContext.Commands.Inputs
{
    public class CriaEspecialidadeCommand : Notifiable, ICommand
    {
        public string descricao {get;set;}
        public void Validate()
        {
             AddNotifications(new ValidationContract()
                 .Requires()
                 .IsNotNull(descricao, "descricao", "descricao é obrigatório")
             );
        }
    }
}