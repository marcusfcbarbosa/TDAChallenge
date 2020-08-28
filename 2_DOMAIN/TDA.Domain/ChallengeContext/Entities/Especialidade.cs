using System.Collections.Generic;
using TDA.Shared.Entities;

namespace TDA.Domain.ChallengeContext.Entities
{
    public class Especialidade : Entity
    {
        public Especialidade(string descricao)
        {
            Descricao = descricao;
        }

        private Especialidade(){}
        
        public string Descricao { get; private set; }

        public List<MedicoEspecialidade> medicoEspecialidades { get; set; } = new List<MedicoEspecialidade>();
        
    }
}