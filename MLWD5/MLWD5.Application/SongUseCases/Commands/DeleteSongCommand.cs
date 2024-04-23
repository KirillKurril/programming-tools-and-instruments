namespace MLWD5.Aplication.SongUseCases.Commands
{
    public sealed record DeleteSongCommand(int SelectedSongId) : IRequest<Song>;
}
