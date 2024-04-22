using System;
namespace MLWD5.Application.SongUseCases.Commands
{
    public class DeleteSongCommandHandler : IRequestHandler<DeleteSongCommand, Song>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Song> Handle(DeleteSongCommand request, CancellationToken cancellationToken)
        {
            var song = await _unitOfWork.SongRepository.GetByIdAsync(request.SelectedSongId);
            await _unitOfWork.SongRepository.DeleteAsync(song, cancellationToken);
            await _unitOfWork.SaveAllAsync();
            return song;
        }
    }
}
