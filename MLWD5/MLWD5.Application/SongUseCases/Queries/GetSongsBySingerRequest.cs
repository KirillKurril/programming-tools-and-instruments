namespace MLWD5.Aplication.SongUseCases.Queries
{
    public sealed record GetSongsBySingerRequest(int SingerId) : IRequest<IEnumerable<Song>>;
}
