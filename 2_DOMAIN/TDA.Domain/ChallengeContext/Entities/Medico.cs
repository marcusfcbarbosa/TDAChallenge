using System.Collections.Generic;
using TDA.Shared.Entities;

namespace TDA.Domain.ChallengeContext.Entities
{
    public class Medico : Entity
    {
        public Medico()
        {
        }

        public Medico(string nome, string cpf, string email, string crm)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Crm = crm;
        }

        public void AdicionaEspecialidade(Especialidade especialidade)
        {
            this.especialidades.Add(especialidade);
        }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public string Crm { get; private set; }
        public List<Especialidade> especialidades { get; set; } = new List<Especialidade>();
    }
}