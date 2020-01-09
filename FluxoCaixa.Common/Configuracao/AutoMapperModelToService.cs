using FluxoCaixa.Common.Models;
using FluxoCaixa.Common.Models.ViewModel;
using FluxoCaixa.Dominio.Entidades;

namespace FluxoCaixa.Common.ConfiguracaoAutoMapper
{
    public class AutoMapperModelToService : AutoMapper.Profile
    {
        public AutoMapperModelToService()
        {
            CreateMap<LancamentoFinanceiroApiModel, LancamentoFinanceiro>()
                .ForPath(_ => _.TipoLancamento.Id, opt => opt.MapFrom(src => (int)src.TipoLancamento));

            CreateMap<LancamentoFinanceiroApiUpdateModel, LancamentoFinanceiro>()
              .ForPath(_ => _.TipoLancamento.Id, opt => opt.MapFrom(src => (int)src.TipoLancamento));

            CreateMap<LancamentoFinanceiroInserirViewModel, LancamentoFinanceiroApiModel>()
                .ForMember(_ => _.TipoLancamento, opt => opt.MapFrom(src => src.TipoLancamento ? Enum.TipoLancamentoEnum.Credito : Enum.TipoLancamentoEnum.Debito));

            CreateMap<LancamentoFinanceiroInserirViewModel, LancamentoFinanceiroApiUpdateModel>()
            .ForPath(_ => _.TipoLancamento, opt => opt.MapFrom(src => src.TipoLancamento ? Enum.TipoLancamentoEnum.Credito : Enum.TipoLancamentoEnum.Debito));

        }
    }
}
