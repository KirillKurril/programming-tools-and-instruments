namespace MLWD5.Aplication.SingerUseCases.Commands
{
    public class EditSingerCommandHandler : IRequestHandler<EditSingerCommand, Singer>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditSingerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Singer> Handle(EditSingerCommand request, CancellationToken cancellationToken)
        {
            Singer changingSinger =
                await _unitOfWork.SingerRepository.GetByIdAsync(request.Id, cancellationToken);
            changingSinger.ChangeInfo(request.Name, request.Age, request.Biography, request.PhotoRef);

            await _unitOfWork.SingerRepository.UpdateAsync(changingSinger, cancellationToken);
            await _unitOfWork.SaveAllAsync();

            return changingSinger;
        }
    }
}
