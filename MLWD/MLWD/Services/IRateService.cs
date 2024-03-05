namespace MLWD.Services
{
    public interface IRateService
    {
        Task GetRatesAsync(DateTime date);
        public Task<double> Convert(double valueFrom, string fromCurrency, string toCurrency, DateTime date);
    }
}
