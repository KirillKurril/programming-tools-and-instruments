using Domain.Abstractions;
using Domain.Entities;
using MLWD5.Domain.Abstractions;
using MLWD5.Persistense.Data;

namespace Persistense.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Singer>> _singerRepository;
        private readonly Lazy<IRepository<Song>> _songRepository;

        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _singerRepository = new Lazy<IRepository<Singer>>(() =>
            new EfRepository<Singer>(context));
            _songRepository = new Lazy<IRepository<Song>>(() =>
             new EfRepository<Song>(context));
        }
        public IRepository<Singer> SingerRepository
         => _singerRepository.Value;
        public IRepository<Song> SongRepository
         => _songRepository.Value;
        public async Task CreateDataBaseAsync() =>
         await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() =>
         await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() =>
         await _context.SaveChangesAsync();
    }
}
