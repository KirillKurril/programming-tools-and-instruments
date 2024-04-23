namespace MLWD5.Aplication.SingerUseCases.Queries
{
    public sealed record GetAllSingersRequest() : IRequest<IEnumerable<Singer>>;
}
