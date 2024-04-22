namespace MLWD5.Application.SongUseCases.Commands
{
    public sealed record DeleteSongCommand(int SelectedSongId) : IRequest<Song>;
}
