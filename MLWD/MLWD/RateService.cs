using MLWD.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;  

namespace MLWD
{
    internal class RateService : IRateService
    {
        private HttpClient httpClient;

        public RateService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Rate>> GetRatesAsync(DateTime date)
        {
            // Формирование относительного пути для запроса курсов валют на указанную дату
            string relativePath = $"rates?ondate={date:yyyy-MM-dd}";

            // Выполнение GET-запроса
            HttpResponseMessage response = await httpClient.GetAsync(relativePath);

            // Проверка статуса ответа
            response.EnsureSuccessStatusCode();

            // Чтение содержимого ответа
            var responseContent = await response.Content.ReadAsStringAsync();

            var rates = JsonConvert.DeserializeObject<IEnumerable<Rate>>(responseContent);

            return rates;
        }
    }
}