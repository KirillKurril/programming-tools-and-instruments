namespace MLWD5.Aplication.SingerUseCases.Queries
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
