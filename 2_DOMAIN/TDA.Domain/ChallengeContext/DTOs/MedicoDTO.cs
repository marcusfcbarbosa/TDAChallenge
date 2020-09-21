using System.Collections.Generic;

namespace TDA.Domain.ChallengeContext.DTOs
{
    //Essas DTOS eu criei, caso fosse usar Dapper para realizar a consulta, mas acabou nem precisando
    public class MedicoDTO
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public ICollection<EspecialidadeDTO> Especialidades { get; set; } = new HashSet<EspecialidadeDTO>();

    }
}