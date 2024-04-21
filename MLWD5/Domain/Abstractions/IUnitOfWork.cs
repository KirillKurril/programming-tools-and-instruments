using MLWD5.Domain.Abstractions;

namespace Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Singer> SingerRepository { get; }
        IRepository<Song> SongRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}


