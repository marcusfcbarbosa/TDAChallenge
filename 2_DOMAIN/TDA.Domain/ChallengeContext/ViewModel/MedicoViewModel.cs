using System.Collections.Generic;

namespace TDA.Domain.ChallengeContext.ViewModel
{
    public class MedicoViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }

        public List<EspecialidadeViewModel> especialidades {get;set;} = new List<EspecialidadeViewModel>();
    }
}