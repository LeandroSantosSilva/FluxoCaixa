using System;
using System.Collections.Generic;
using System.Text;

namespace FluxoCaixa.Data.Seed
{
    public class SeedProducao : Seed
    {
        public SeedProducao(FluxoCaixaContext fluxoCaixaContext) : base(fluxoCaixaContext) { }

        protected override void RunAsync(bool migrate)
        {
            base.RunAsync(migrate); 
        }
    }
}
