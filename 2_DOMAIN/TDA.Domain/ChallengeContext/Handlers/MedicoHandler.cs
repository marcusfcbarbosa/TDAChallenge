using FluentValidator;
using TDA.Domain.ChallengeContext.Commands.Inputs;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Shared.Commands;

namespace TDA.Domain.ChallengeContext.Handlers
{
    public class MedicoHandler : Notifiable,
    ICommandHandler<CriaMedicoCommand>,
    ICommandHandler<CriaEspecialidadeCommand>
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IEspecialidadeRepository _especialidadeRepository;
        public MedicoHandler(
            IMedicoRepository medicoRepository,
            IEspecialidadeRepository especialidadeRepository)
        {
            _medicoRepository = medicoRepository;
            _especialidadeRepository = especialidadeRepository;
        }

        public ICommandResult Handle(CriaMedicoCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handle(CriaEspecialidadeCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}