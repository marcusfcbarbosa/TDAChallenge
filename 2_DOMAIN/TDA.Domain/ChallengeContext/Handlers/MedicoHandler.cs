using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using TDA.Domain.ChallengeContext.Adapter;
using TDA.Domain.ChallengeContext.Commands.Inputs;
using TDA.Domain.ChallengeContext.Commands.Outputs;
using TDA.Domain.ChallengeContext.Entities;
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
        private readonly IMedicoEspecialidadeRespository _medicoEspecialidadeRespository;
        public MedicoHandler(
            IMedicoRepository medicoRepository,
            IEspecialidadeRepository especialidadeRepository,
            IUserRepository userRepository,
            IMedicoEspecialidadeRespository medicoEspecialidadeRespository)
        {
            _medicoRepository = medicoRepository;
            _especialidadeRepository = especialidadeRepository;
            _userRepository = userRepository;
            _medicoEspecialidadeRespository = medicoEspecialidadeRespository;
        }

        public ICommandResult Handle(CriaMedicoCommand command)
        {
            command.Validate();
            if (!command.Valid)
            {
                return new CommandResult(false, "Erros", command.Notifications);
            }
            
            List<Especialidade> listEsp = new List<Especialidade>();
            for (int i = 0; i < command.especialidades.Count(); i++)
            {
                var especialidade = new Especialidade(command.especialidades[i]);
                _especialidadeRepository.Create(especialidade);
                _especialidadeRepository.SaveChanges();
                listEsp.Add(especialidade);
            }
            var medico = new Medico(command.nome, command.cpf, command.crm);
            _medicoRepository.Create(medico);
            _medicoRepository.SaveChanges();
            for (int i = 0; i < listEsp.Count(); i++)
            {
                var medicoEspecialidade = new MedicoEspecialidade(medico, (listEsp[i] as Especialidade));
                _medicoEspecialidadeRespository.Create(medicoEspecialidade);
                _medicoEspecialidadeRespository.SaveChanges();
            }
            return new CommandResult(true, "Medico cadastrado com sucesso!", MedicoAdapter.DomainToViewModel(medico));
        }

        public ICommandResult Handle(CriaUserCommand command)
        {
            command.Validate();
            if (!command.Valid)
            {
                return new CommandResult(false, "Erros", command.Notifications);
            }
            var user = new User(command.UserName, command.PassWord, command.Role);
            _userRepository.Create(user);
            _userRepository.SaveChanges();
            return new CommandResult(true, "Usuario Criado com sucesso!", UserAdapter.DomainToViewModel(user));
        }

        public ICommandResult Handle(CriaEspecialidadeCommand command)
        {
            command.Validate();
            if (!command.Valid)
            {
                return new CommandResult(false, "Erros", command.Notifications);
            }
            var especialidade = new Especialidade(command.descricao);
            _especialidadeRepository.Create(especialidade);
            _especialidadeRepository.SaveChanges();
            return new CommandResult(true, "", null);
        }


    }
}