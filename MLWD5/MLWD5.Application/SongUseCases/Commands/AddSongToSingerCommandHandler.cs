namespace MLWD5.Aplication.SongUseCases.Commands
{
    public class AddSongToSingerCommandHandler : IRequestHandler<AddSongToSingerCommand, Song>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSongToSingerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Song> Handle(AddSongToSingerCommand request, CancellationToken cancellationToken)
        {
            Song newSong = new Song(request.Name, request.Description, request.Text, request.ChartPosition, request.Id, request.PhotoSource ,request.SingerId);
            await _unitOfWork.SongRepository.AddAsync(newSong);
            await _unitOfWork.SaveAllAsync();
            return newSong;
        }
    }
}
