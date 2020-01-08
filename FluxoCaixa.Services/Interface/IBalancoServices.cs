using FluxoCaixa.Dominio.DTO;
using System;
using System.Collections.Generic;

namespace FluxoCaixa.Services.Interface
{
    public interface IBalancoServices
    {
        void GerarBalancoDiario();
        List<BalancoMensal> BuscarBalancoMensal(DateTime? ano, DateTime? mesParametro);
    }
}
