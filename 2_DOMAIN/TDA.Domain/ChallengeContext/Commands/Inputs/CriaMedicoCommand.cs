using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using FluentValidator.Validation;
using TDA.Domain.Utils;
using TDA.Shared.Commands;

namespace TDA.Domain.ChallengeContext.Commands.Inputs
{
    public class CriaMedicoCommand : Notifiable, ICommand
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string crm { get; set; }
        public List<string> especialidades { get; set; } = new List<string>();
        public void Validate()
        {
            AddNotifications(new ValidationContract()
                 .Requires()
                 .IsNotNull(nome, "Nome", "Nome é obrigatório")
                 .IsNotNull(cpf, "cpf", "cpf é obrigatório")
                 .IsNotNull(crm, "crm", "crm é obrigatório")
                 .IsTrue(Util.ValidaCpf(cpf), "cpf", "cpf inválido")
             );
        }
    }
}