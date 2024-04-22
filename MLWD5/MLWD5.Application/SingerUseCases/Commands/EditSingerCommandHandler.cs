using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLWD5.Application.SingerUseCases.Commands
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
