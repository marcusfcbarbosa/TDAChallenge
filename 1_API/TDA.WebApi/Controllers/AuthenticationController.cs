using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TDA.Domain.ChallengeContext.Adapter;
using TDA.Domain.ChallengeContext.Commands.Inputs.Authentication;
using TDA.Domain.ChallengeContext.Commands.Outputs;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;
using TDA.Shared.Commands;
using TDA.WebApi.services;

namespace TDA.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController
    {
        private readonly IUserRepository _userrepository;

        public AuthenticationController(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }

        [HttpPost("")]
        [AllowAnonymous]
        public async Task<ICommandResult> Post([FromBody] AuthenticationCommand command)
        {
            try
            {
                if (!command.Valid)
                {
                    return new CommandResult(false, "Campos enviados com erro", command.Notifications);
                }
                var user = await _userrepository.retornaPorNomeSenha(command.UserName, command.PassWord);
                if (user != null)
                {
                    var token = TokenService.GenerateToken(user);
                    return new CommandResult(true, "", new
                    {
                        user = UserAdapter.DomainToViewModel(user),
                        token = "Bearer "+ token
                    });
                }
                else
                {
                    return new CommandResult(false, "404", StatusCodes.Status404NotFound);
                }

            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

    }
}