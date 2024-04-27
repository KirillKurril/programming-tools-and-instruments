namespace MLWD5.Aplication.SongUseCases.Commands
{
    public sealed record AddSongToSingerCommand(int Id,
        string Name,
        string Description,
        string Text,
        int ChartPosition,
        int SingerId) : IRequest<Song>;
}
