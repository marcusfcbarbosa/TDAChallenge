using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TDA.Domain.ChallengeContext.Adapter;
using TDA.Domain.ChallengeContext.Commands.Inputs.Requests;
using TDA.Domain.ChallengeContext.Commands.Outputs;
using TDA.Domain.ChallengeContext.Entities;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Shared.Commands;

namespace TDA.Domain.ChallengeContext.Handlers.Request
{
    public class MedicoRequestHandler : IRequestHandler<CriaMedicoCommandRequest, ICommandResult>
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly IEspecialidadeRepository _especialidadeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMedicoEspecialidadeRespository _medicoEspecialidadeRespository;

        public MedicoRequestHandler(IMedicoRepository medicoRepository, IEspecialidadeRepository especialidadeRepository, IUserRepository userRepository, IMedicoEspecialidadeRespository medicoEspecialidadeRespository)
        {
            _medicoRepository = medicoRepository;
            _especialidadeRepository = especialidadeRepository;
            _userRepository = userRepository;
            _medicoEspecialidadeRespository = medicoEspecialidadeRespository;
        }

        public async Task<ICommandResult> Handle(CriaMedicoCommandRequest command, CancellationToken cancellationToken)
        {
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
            return await Task.FromResult(new CommandResult(true, "Medico cadastrado com sucesso!", MedicoAdapter.DomainToViewModel(medico)));
        }
    }
}