using FluxoCaixa.ClientServices.Interfaces;
using FluxoCaixa.Common.Configuracao;
using FluxoCaixa.Common.Constantes;
using FluxoCaixa.Common.Helpers;
using FluxoCaixa.Common.Models;
using FluxoCaixa.Dominio.Entidades;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FluxoCaixa.ClientServices.ClientServices
{
    public class LancamentoFinanceiroService : ILancamentoFinanceiroClientServices
    {
        private readonly HttpClient _httpClient = default;
        private readonly IOptions<CustomConfiguration> _customConfiguration;

        public LancamentoFinanceiroService(HttpClient httpClient, IOptions<CustomConfiguration> customConfiguration)
        {
            _httpClient = httpClient;
            _customConfiguration = customConfiguration;

        }

        public void AtualizarLancamentoFinanceiro(LancamentoFinanceiroApiUpdateModel model)
        {
            try
            {
                var dados = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = _httpClient.PostAsync(ClientServiceHelpers.ConfigurarUrl(_customConfiguration, Servicos.SERVICO_ATUALIZAR_LANCAMENTO_FINANCEIRO), dados))
                {
                    var retornoApi = response.Result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ExcluirLancamentoFinanceiro(int id)
        {
            try
            {
                var urlComParametros = $"{ClientServiceHelpers.ConfigurarUrl(_customConfiguration, Servicos.SERVICO_DELETAR_LANCAMENTO_FINANCEIRO)}?id={id}";

                using (var response = _httpClient.DeleteAsync(urlComParametros))
                {
                    var retornoApi = response.Result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LancamentoFinanceiro> FiltrarLancamentosFinanceiro(LancamentoFinanceiroFiltro filtro)
        {
            try
            {
                var urlComParametros = $"{ClientServiceHelpers.ConfigurarUrl(_customConfiguration, Servicos.SERVICO_FILTRAR_LANCAMENTO_FINANCEIRO)}?" +
                                       $"DataLancamento={filtro.DataLancamento}&" +
                                       $"TipoLancamento={filtro.TipoLancamento}&" +
                                       $"Consolidado={filtro.Consolidado}";

                using (var response = _httpClient.GetAsync(urlComParametros))
                {
                    var retornoApi = response.Result.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<LancamentoFinanceiro>>(retornoApi.Result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InserirLancamentoFinaneiro(LancamentoFinanceiroApiModel model)
        {
            try
            {
                var dados = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = _httpClient.PostAsync(ClientServiceHelpers.ConfigurarUrl(_customConfiguration, Servicos.SERVICO_INSERIR_LANCAMENTO_FINANCEIRO), dados))
                {
                    var retornoApi = response.Result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
