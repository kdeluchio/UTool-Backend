using System.Linq;
using UTools.Application.Dtos;
using UTools.Domain.Entities;

namespace UTools.Infra.CrossCutting
{
    public class Mappers : AutoMapper.Profile
    {
        public Mappers()
        {
            CreateMap<CadastroEmpresaDTO, Empresa>()
                .ForMember(c => c.CnaeCodigo, opt => opt.MapFrom(c => c.Atividade_principal.First().Code))
                .ForMember(c => c.CnaeDescricao, opt => opt.MapFrom(c => c.Atividade_principal.First().Text))
                .ForMember(c => c.NaturezaJuridica, opt => opt.MapFrom(c => c.Natureza_juridica))
                .ForMember(c => c.DataSituacao, opt => opt.MapFrom(c => c.Data_situacao))
                .ForMember(c => c.CapitalSocial, opt => opt.MapFrom(c => c.Capital_social))
                .ReverseMap();
        }

    }
}
