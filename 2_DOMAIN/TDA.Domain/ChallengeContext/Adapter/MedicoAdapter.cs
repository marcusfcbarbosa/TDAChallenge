using System.Collections.Generic;
using System.Linq;
using TDA.Domain.ChallengeContext.DTOs;
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
                Cpf = medico.Cpf,
                Crm = medico.Crm,
                Nome = medico.Nome,
                especialidades = medico.medicoEspecialidades.Any() ? medico.medicoEspecialidades.Select(x => x.especialidade).ToList().Select(ToDomainEspecialidadeViewModel).ToList() : new List<EspecialidadeViewModel>()
            };
        }

        public static MedicoViewModel DtoToViewModel(MedicoDTO medico)
        {
            return new MedicoViewModel
            {
                Cpf = medico.Cpf,
                Crm = medico.Crm,
                Nome = medico.Nome,
                especialidades = medico.Especialidades != null ? medico.Especialidades.Select(ToEspecialidadeViewModel).ToList() : new List<EspecialidadeViewModel>()
            };
        }

        public static EspecialidadeViewModel ToDomainEspecialidadeViewModel(Especialidade especialidade)
        {
            return new EspecialidadeViewModel
            {
                Descricao = especialidade.Descricao
            };
        }

        public static EspecialidadeViewModel ToEspecialidadeViewModel(EspecialidadeDTO especialidade)
        {
            return new EspecialidadeViewModel
            {
                Descricao = especialidade.Descricao
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
                        Nome = medicos.ElementAt(i).Nome,
                        Crm = medicos.ElementAt(i).Crm,
                        Cpf = medicos.ElementAt(i).Cpf,
                        especialidades = medicos.ElementAt(i).medicoEspecialidades.Any() ? medicos.ElementAt(i).medicoEspecialidades.Select(x => x.especialidade).ToList().Select(ToDomainEspecialidadeViewModel).ToList() : new List<EspecialidadeViewModel>()
                    }
                );
            }
            return list;
        }
    }
}