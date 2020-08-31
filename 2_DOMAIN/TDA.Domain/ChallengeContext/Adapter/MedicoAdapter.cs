using System.Collections.Generic;
using System.Linq;
using TDA.Domain.ChallengeContext.Entities;
using TDA.Domain.ChallengeContext.ViewModel;

namespace TDA.Domain.ChallengeContext.Adapter
{
    public static class MedicoAdapter
    {

        public static MedicoViewModel DomainToViewModel(Medico medico)
        {

            return new MedicoViewModel
            {
                identifyer = medico.identifyer,
                Cpf = medico.Cpf,
                Crm = medico.Crm,
                Nome = medico.Nome
            };
        }

        public static IEnumerable<MedicoViewModel> DomainToViewModel(IEnumerable<Medico> medicos)
        {
            List<MedicoViewModel> list = new List<MedicoViewModel>();
            for (int i = 0; i < medicos.Count(); i++)
            {
                list.Add(
                    new MedicoViewModel
                    {
                        identifyer = medicos.ElementAt(i).identifyer,
                        Nome = medicos.ElementAt(i).Nome,
                        Crm = medicos.ElementAt(i).Crm,
                        Cpf = medicos.ElementAt(i).Cpf
                    }
                );
            }
            return list;
        }


    }
}