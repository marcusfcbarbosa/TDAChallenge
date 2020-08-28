using Microsoft.AspNetCore.Mvc;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;

namespace TDA.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }
    }
}