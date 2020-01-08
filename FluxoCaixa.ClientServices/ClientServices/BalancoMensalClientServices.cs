﻿using FluxoCaixa.ClientServices.Interfaces;
using FluxoCaixa.Common.Configuracao;
using FluxoCaixa.Common.Constantes;
using FluxoCaixa.Common.Helpers;
using FluxoCaixa.Common.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FluxoCaixa.ClientServices.ClientServices
{
    public class BalancoMensalClientServices : IBalancoMensalClientService
    {
        private readonly HttpClient _httpClient = default;
        private readonly IOptions<CustomConfiguration> _customConfiguration;
        public BalancoMensalClientServices(HttpClient httpClient, IOptions<CustomConfiguration> customConfiguration)
        {
            _httpClient = httpClient;
            _customConfiguration = customConfiguration;
        }

        public IEnumerable<BalancoMensalModel> GetBalancoMensal(int? ano, int? mes)
        {
            try
            {
                using (var response = _httpClient.GetAsync(ClientServiceHelpers.ConfigurarUrl(_customConfiguration, Servicos.SERVICO_BALANCO_MENSAL)))
                {
                    var retornoApi = response.Result.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<BalancoMensalModel>>(retornoApi.Result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
