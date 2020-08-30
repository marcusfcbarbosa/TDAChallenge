using FluentValidator;
using TDA.Domain.ChallengeContext.Adapter;
using TDA.Domain.ChallengeContext.Commands.Inputs;
using TDA.Domain.ChallengeContext.Commands.Outputs;
using TDA.Domain.ChallengeContext.Entities.Authentication;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Shared.Commands;

namespace TDA.Domain.ChallengeContext.Handlers
{
    public class MedicoHandler : Notifiable,
    ICommandHandler<CriaMedicoCommand>,
    ICommandHandler<CriaEspecialidadeCommand>,
    ICommandHandler<CriaUserCommand>
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IUserRepository _userRepository;
        public MedicoHandler(
            IMedicoRepository medicoRepository,
            IEspecialidadeRepository especialidadeRepository,
            IUserRepository userRepository)
        {
            _medicoRepository = medicoRepository;
            _especialidadeRepository = especialidadeRepository;
            _userRepository = userRepository;
        }

        public ICommandResult Handle(CriaMedicoCommand command)
        {
            command.Validate();
            if (!command.Valid)
            {
                return new CommandResult(false, "Campos enviados com erro", command.Notifications);
            }
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(CriaUserCommand command)
        {
            command.Validate();
            if (!command.Valid)
            {
                return new CommandResult(false, "Campos enviados com erro", command.Notifications);
            }
            var user = new User(command.UserName,command.PassWord,command.Role);
            _userRepository.Create(user);
            _userRepository.SaveChanges();
            return new CommandResult(true, "Usuario Criado com sucesso!", UserAdapter.DomainToViewModel(user));
        }

        public ICommandResult Handle(CriaEspecialidadeCommand command)
        {
            command.Validate();
            if (!command.Valid)
            {
                return new CommandResult(false, "Campos enviados com erro", command.Notifications);
            }
            throw new System.NotImplementedException();
        }


    }
}