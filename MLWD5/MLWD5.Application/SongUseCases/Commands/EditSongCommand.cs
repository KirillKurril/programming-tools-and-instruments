namespace MLWD5.Application.SongUseCases.Commands
{
    public sealed record EditSongCommand(int Id,
        string Name,
        string Description,
        string Text,
        int ChartPosition) : IRequest<Song>;
}
