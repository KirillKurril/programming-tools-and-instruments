namespace MLWD.Services
{
    public interface IRateService
    {
        Task<IEnumerable<Rate>> GetRatesAsync(DateTime date);
    }
}
