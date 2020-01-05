using FluxoCaixa.Common.Models;
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
        }
    }
}
