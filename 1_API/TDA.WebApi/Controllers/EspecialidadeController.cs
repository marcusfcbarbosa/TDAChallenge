using Microsoft.AspNetCore.Mvc;
using TDA.Domain.ChallengeContext.Repositories.Interfaces;

namespace TDA.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadeController
    {

         private readonly IEspecialidadeRepository _especialidadeRepository;
        public EspecialidadeController(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
        }

    }
}