using MLWD5.Persistense.Data;

namespace Persistense.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        //private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Singer>> _singerRepository;
        private readonly Lazy<IRepository<Song>> _songRepository;

        public FakeUnitOfWork(AppDbContext context)
        {
            /*_context = context;*/
            _singerRepository = new Lazy<IRepository<Singer>>(() =>
            new EfRepository<Singer>(context));
            _songRepository = new Lazy<IRepository<Song>>(() =>
             new EfRepository<Song>(context));
        }
        public IRepository<Singer> SingerRepository
        => _singerRepository.Value;
        public IRepository<Song> SongRepository
         => _songRepository.Value;

        public Task SaveAllAsync()
        {
            return Task.CompletedTask;
        }

        public Task DeleteDataBaseAsync()
        {
            return Task.CompletedTask;
        }

        public Task CreateDataBaseAsync()
        {
            return Task.CompletedTask;
        }
    }
}
