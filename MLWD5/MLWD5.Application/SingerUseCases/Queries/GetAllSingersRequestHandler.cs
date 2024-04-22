using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLWD5.Application.SingerUseCases.Queries
{
    public class GetAllSingersRequestHandler : IRequestHandler<GetAllSingersRequest, IEnumerable<Singer>>
    {
        private IRepository<Singer> _singerRepository;

        public GetAllSingersRequestHandler(IRepository<Singer> SingerRepository)
        {
            _singerRepository = SingerRepository;
        }

        public async Task<IEnumerable<Singer>> Handle(GetAllSingersRequest request, CancellationToken cancellationToken)
        {
            var Singers = await _singerRepository.ListAllAsync(cancellationToken);
            return Singers;
        }
    }
}
