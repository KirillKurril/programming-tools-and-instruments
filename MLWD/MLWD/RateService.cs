using MLWD.Services;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NbrbAPI.Models;

namespace MLWD
{
    internal class RateService : IRateService
    {
        DateTime lastDate;
        private HttpClient httpClient;
        private Dictionary<string, double> Rates;
        private string[] currentsToGet;

        public RateService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            Rates = new Dictionary<string, double>()
            {
                 { "BYR", 1 },
                 { "RUB", -1 },
                 { "USD", -1 },
                 { "EUR", -1 },
                 { "CNY", -1 },
                 { "GBP", -1 },
                 { "CHF", -1 }
            };
        }

        public async Task GetRatesAsync(DateTime date)
        {
            foreach (var currencyAbbriviation in Rates.Keys.Skip(1))
            {
                string url = new Uri(httpClient.BaseAddress, $"{currencyAbbriviation}?parammode=2&ondate={date:yyyy-MM-dd}").AbsoluteUri;

                HttpResponseMessage response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var rate = JsonConvert.DeserializeObject<Rate>(json);
                Rates[currencyAbbriviation] = (double)rate.Cur_OfficialRate / rate.Cur_Scale;
                
            }
        }
        public async Task<double> Convert(double valueFrom, string fromCurrency, string toCurrency, DateTime date)
        {
            if(lastDate != date)
            {
                await GetRatesAsync(date);
                lastDate = date;
            }
            return   Rates[fromCurrency] / Rates[toCurrency] * valueFrom;
        }
    }
}