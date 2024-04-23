namespace MLWD5.Aplication.SingerUseCases.Commands
{
    public class DeleteSingerCommandHandler : IRequestHandler<DeleteSingerCommand, Singer>
    {
        public DeleteSingerCommandHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        IUnitOfWork _unitOfWork;

        public async Task<Singer> Handle(DeleteSingerCommand request, CancellationToken cancellationToken)
        {
            Singer removableSinger = await _unitOfWork.SingerRepository.GetByIdAsync(request.Id, cancellationToken);
            var removableSingerSongs = await _unitOfWork.SongRepository.ListAsync(song => song.SingerId.Equals(request.Id), cancellationToken);
            foreach (var song in removableSingerSongs)
                await _unitOfWork.SongRepository.DeleteAsync(song);

            await _unitOfWork.SaveAllAsync();
            return removableSinger;
        }
    }
}
