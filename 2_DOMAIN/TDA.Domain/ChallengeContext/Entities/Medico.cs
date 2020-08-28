using System.Collections.Generic;
using TDA.Shared.Entities;

namespace TDA.Domain.ChallengeContext.Entities
{
    public class Medico : Entity
    {
        private Medico() { }
        public Medico(string nome, string cpf, string crm)
        {
            Nome = nome;
            Cpf = cpf;
            Crm = crm;
        }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Crm { get; private set; }
        public List<MedicoEspecialidade> medicoEspecialidades { get; set; } = new List<MedicoEspecialidade>();
    }
}