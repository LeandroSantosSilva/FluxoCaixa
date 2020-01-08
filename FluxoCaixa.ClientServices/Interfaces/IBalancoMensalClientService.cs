using FluxoCaixa.Common.Models;
using FluxoCaixa.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluxoCaixa.ClientServices.Interfaces
{
    public interface IBalancoMensalClientService
    {
        IEnumerable<BalancoMensalModel> GetBalancoMensal(int? ano, int? mes);
    }
}
