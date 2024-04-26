namespace MLWD5.Aplication.SongUseCases.Queries
{
    public class GetSongsBySingerHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetSongsBySingerRequest, IEnumerable<Song>>
    {
        public async Task<IEnumerable<Song>> Handle(GetSongsBySingerRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.SongRepository
            .ListAsync(song => song.SingerId == request.SingerId,//vsong.SingerId.Equals(request.SingerId),
           cancellationToken);
        }
    }
}
