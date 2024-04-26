namespace MLWD5.Aplication.SingerUseCases.Commands
{
    public class AddSingerCommandHandler : IRequestHandler<AddSingerCommand, Singer>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSingerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Singer> Handle(AddSingerCommand request, CancellationToken cancellationToken)
        {
            //Singer newSinger = new Singer(request.Id, request.Name, request.Age, request.Biography, request.PhotoRef);
            Singer newSinger = new Singer(request.Name, request.Age, request.Biography, request.PhotoRef);
            await _unitOfWork.SingerRepository.AddAsync(newSinger);
            await _unitOfWork.SaveAllAsync();
            return newSinger;
        }
    }
}
