using TDA.Shared.Entities;

namespace TDA.Domain.ChallengeContext.Entities
{
    public class MedicoEspecialidade :  Entity
    {
        private MedicoEspecialidade() { }
        public MedicoEspecialidade(Medico medico, Especialidade especialidade)
        {
            this.medico = medico;
            this.especialidade = especialidade;
        }

        public long medicoId { get; private set; }
        public Medico medico { get; private set; }
        public long especialidadeId { get; private set; }
        public Especialidade especialidade { get; private set; }

    }
}