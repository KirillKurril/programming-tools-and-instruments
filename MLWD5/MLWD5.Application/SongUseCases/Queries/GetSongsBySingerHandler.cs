namespace MLWD5.Application.SongUseCases.Queries
{
    public class GetSongsBySingerHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetSongsBySingerRequest, IEnumerable<Song>>
    {
        public async Task<IEnumerable<Song>> Handle(GetSongsBySingerRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.SongRepository
            .ListAsync(song => song.SingerId.Equals(request.SingerId),
           cancellationToken);
        }
    }
}
