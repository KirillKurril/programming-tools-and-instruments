namespace MLWD5.Aplication.SingerUseCases.Commands
{
    public sealed record EditSingerCommand(int Id, string Name, int Age, string Biography, string PhotoRef) : IRequest<Singer>;
}
