namespace MLWD5.Aplication.SingerUseCases.Commands
{
    public sealed record DeleteSingerCommand(int Id) : IRequest<Singer>;
}
