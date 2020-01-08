using FluxoCaixa.Dominio.DTO;
using System;
using System.Collections.Generic;

namespace FluxoCaixa.Data.Interface
{
    public interface IBalancoRepositorio
    {
        void GerarBalancoDiario();
        List<BalancoMensal> BuscarBalancoMensal(DateTime? ano, DateTime? mesParametro);
    }
}
