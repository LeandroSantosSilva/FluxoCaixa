using FluxoCaixa.Data.Interface;
using FluxoCaixa.Dominio.DTO;
using FluxoCaixa.Services.Interface;
using System;
using System.Collections.Generic;

namespace FluxoCaixa.Services
{
    public class BalancoServices : IBalancoServices
    {
        private readonly IBalancoRepositorio _balancoRepositorio;
        public BalancoServices(IBalancoRepositorio balancoRepositorio)
        {
            _balancoRepositorio = balancoRepositorio;
        }

        public List<BalancoMensal> BuscarBalancoMensal(DateTime? ano, DateTime? mesParametro)
        {
           return _balancoRepositorio.BuscarBalancoMensal(ano, mesParametro);
        }

        public void GerarBalancoDiario()
        {
            _balancoRepositorio.GerarBalancoDiario();
        }
    }
}
