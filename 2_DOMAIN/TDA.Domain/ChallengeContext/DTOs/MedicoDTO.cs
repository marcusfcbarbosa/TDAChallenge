using System.Collections.Generic;

namespace TDA.Domain.ChallengeContext.DTOs
{
    public class MedicoDTO
    {

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public ICollection<EspecialidadeDTO> Especialidades { get; set; } = new HashSet<EspecialidadeDTO>();

    }
}