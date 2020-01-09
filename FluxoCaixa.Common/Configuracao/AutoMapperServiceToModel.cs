using FluxoCaixa.Common.Models;
using FluxoCaixa.Common.Models.ViewModel;
using FluxoCaixa.Dominio.Entidades;

namespace FluxoCaixa.Common.ConfiguracaoAutoMapper
{
    public class AutoMapperServiceToModel : AutoMapper.Profile
    {
        public AutoMapperServiceToModel()
        {
            CreateMap<LancamentoFinanceiroModel, LancamentoFinanceiroViewModel>()
                .ForMember(_ => _.Consolidado, opt => opt.MapFrom(src => src.Consolidado ? "Sim" : "Não"))
                .ForMember(_ => _.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(_ => _.DataHoraLancamento, opt => opt.MapFrom(src => src.DataHoraLancamento.ToShortDateString()))
                .ForMember(_ => _.Valor, opt => opt.MapFrom(src => src.Valor.ToString("N2")))
                .ForMember(_ => _.TipoLancamento, opt => opt.MapFrom(src => src.TipoLancamento == (int)Enum.TipoLancamentoEnum.Credito ? "Crédito" : "Débito"));

            CreateMap<LancamentoFinanceiro, LancamentoFinanceiroModel>()
                .ForMember(_ => _.TipoLancamento, opt => opt.MapFrom(src => src.TipoLancamento.Id));

            CreateMap<LancamentoFinanceiroModel, LancamentoFinanceiroInserirViewModel>()
                .ForMember(_ => _.TipoLancamento, opt => opt.MapFrom(src => src.TipoLancamento))
                .ForMember(_ => _.Valor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(_ => _.Id, opt => opt.MapFrom(src => src.Id));    

        }
    }
}
