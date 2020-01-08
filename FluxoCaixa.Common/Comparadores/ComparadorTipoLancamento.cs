using FluxoCaixa.Dominio.Entidades;
using System.Collections.Generic;

namespace FluxoCaixa.Common.Comparadores
{
    public class ComparadorTipoLancamento<T> : IEqualityComparer<TipoLancamento>
    {
        public bool Equals(TipoLancamento x, TipoLancamento y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(TipoLancamento obj)
        {
            return 0;
        }
    }
}