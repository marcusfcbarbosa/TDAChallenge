using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using MediatR;
using TDA.Domain.Utils;
using TDA.Shared.Commands;

namespace TDA.Domain.ChallengeContext.Commands.Inputs.Requests
{
    public class CriaMedicoCommandRequest : IRequest<ICommandResult>
    {
        
        public string nome { get; set; }
        public string cpf { get; set; }
        public string crm { get; set; }
        public List<string> especialidades { get; set; } = new List<string>();
        
    }
}