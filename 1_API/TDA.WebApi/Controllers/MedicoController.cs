using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TDA.Domain.ChallengeContext.Adapter;
using TDA.Domain.ChallengeContext.Commands.Inputs;
using TDA.Domain.ChallengeContext.Commands.Outputs;
using TDA.Domain.ChallengeContext.Handlers;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Shared.Commands;

namespace TDA.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController
    {
        private readonly MedicoHandler _medicoHandler;
        private readonly IMedicoRepository _medicoRepository;
        public MedicoController(IMedicoRepository medicoRepository, MedicoHandler medicoHandler)
        {
            _medicoRepository = medicoRepository;
            _medicoHandler = medicoHandler;
        }

        [HttpPost("")]
        public ICommandResult Post([FromBody] CriaMedicoCommand command)
        {
            try
            {
                return _medicoHandler.Handle(command);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("")]
        public async Task<ICommandResult> Get()
        {
            try
            {
                var clientes = MedicoAdapter.DomainToViewModel(await _medicoRepository.ListaMedicos());
                return new CommandResult(true, "", clientes);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

    }
}