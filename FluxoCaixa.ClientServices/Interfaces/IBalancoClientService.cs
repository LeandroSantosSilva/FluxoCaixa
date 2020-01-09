using FluxoCaixa.Common.Models;
using System.Collections.Generic;

namespace FluxoCaixa.ClientServices.Interfaces
{
    public interface IBalancoClientService
    {
        IEnumerable<BalancoMensalModel> GetBalancoMensal(int? ano, int? mes);

        void GerarBalancoDiario();
    }
}
