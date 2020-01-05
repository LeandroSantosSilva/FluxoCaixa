using FluxoCaixa.Common.Models;
using FluxoCaixa.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluxoCaixa.Common.ConfiguracaoAutoMapper
{
    public class AutoMapperModelToService : AutoMapper.Profile
    {
        public AutoMapperModelToService()
        {
            CreateMap<LancamentoFinanceiroApiModel, LancamentoFinanceiro>()
                .ForPath(_ => _.TipoLancamento.Id, opt => opt.MapFrom(src => (int)src.TipoLancamento));
        }
    }
}
