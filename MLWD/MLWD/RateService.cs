using MLWD.Services;

namespace MLWD
{
    internal class RateService : IRateService
    {
        private HttpClient httpClient;

        public RateService(HttpClient httpClient) 
        { 
            this.httpClient = httpClient;
        }
        public IEnumerable<Rate> GetRates(DateTime date)
        {
            return new List<Rate>();
        }
    }
}
