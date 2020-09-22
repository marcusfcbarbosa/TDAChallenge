using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TDA.Domain.ChallengeContext.Adapter;
using TDA.Domain.ChallengeContext.Commands.Inputs;
using TDA.Domain.ChallengeContext.Commands.Inputs.Requests;
using TDA.Domain.ChallengeContext.Commands.Outputs;
using TDA.Domain.ChallengeContext.Handlers;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Shared.Commands;

namespace TDA.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoMediatorController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        public async Task<ICommandResult> Create([FromServices] IMediator mediator,
        [FromBody] CriaMedicoCommandRequest command)
        {
            return await mediator.Send(command);
        }

    }
}