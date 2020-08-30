using FluentValidator;
using TDA.Domain.ChallengeContext.Commands.Inputs.Authentication;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Shared.Commands;

namespace TDA.Domain.ChallengeContext.Handlers.Authentication
{
    public class AuthenticationHandler : Notifiable,
    ICommandHandler<AuthenticationCommand>
    {
       private readonly IUserRepository _userRepository;
        public AuthenticationHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICommandResult Handle(AuthenticationCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}