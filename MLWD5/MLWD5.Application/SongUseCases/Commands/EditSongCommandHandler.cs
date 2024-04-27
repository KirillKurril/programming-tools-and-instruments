namespace MLWD5.Aplication.SongUseCases.Commands
{
    public class EditSongCommandHandler : IRequestHandler<EditSongCommand, Song>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditSongCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Song> Handle(EditSongCommand request, CancellationToken cancellationToken)
        {
            Song changingSong =
                await _unitOfWork.SongRepository.GetByIdAsync(request.Id, cancellationToken);

            changingSong.ChangeInfo(request.Name, request.Description, request.Text, request.ChartPosition, request.SingerId);

            await _unitOfWork.SongRepository.UpdateAsync(changingSong, cancellationToken);
            await _unitOfWork.SaveAllAsync();

            return changingSong;
        }
    }
}
