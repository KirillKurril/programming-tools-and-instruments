using MLWD5.Domain.Entities;
using System.Linq.Expressions;

namespace Persistense.Repository
{
    internal class FakeSongRepository : IRepository<Song>
    {
        List<Song> _songs = new List<Song>();
        public FakeSongRepository()
        {
            Song song1 = new Song("Imagine", "A beautiful song by John Lennon", "Imagine there's no heaven...", 1);
            song1.AddToSinger(1);
            song1.SetPhotoSource("C:/Uni/programming-tools-and-instruments/MLWD5/MLWD5.UI/Resources/Images/default_singer_photo.png");

            _songs.Add(song1);

            Song song2 = new Song("Bohemian Rhapsody", "Iconic song by Queen", "Is this the real life...", 2);
            song2.AddToSinger(2);
            song2.SetPhotoSource("C:/Uni/programming-tools-and-instruments/MLWD5/MLWD5.UI/Resources/Images/default_singer_photo.png");

            _songs.Add(song2);

            Song song3 = new Song("Rolling in the Deep", "Powerful song by Adele", "There's a fire starting in my heart...", 3);
            song3.AddToSinger(3);
            song3.SetPhotoSource("C:/Uni/programming-tools-and-instruments/MLWD5/MLWD5.UI/Resources/Images/default_singer_photo.png");

            _songs.Add(song3);
        }

        public Task<Song> GetByIdAsync(int id, CancellationToken
        cancellationToken = default,
        params Expression<Func<Song, object>>[]?
        includesProperties)
            => throw new NotImplementedException();

        public async Task<IReadOnlyList<Song>> ListAllAsync(CancellationToken
        cancellationToken = default)
             => await Task.Run(() => _songs);

        public async Task<IReadOnlyList<Song>> ListAsync(Expression<Func<Song, bool>>
        filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<Song, object>>[]?
        includesProperties)
            => await Task.Run(() => _songs);

        public async Task AddAsync(Song entity, CancellationToken cancellationToken
        = default)
            => throw new NotImplementedException();

        public async Task UpdateAsync(Song entity, CancellationToken
        cancellationToken = default)
            => throw new NotImplementedException();

        public async Task DeleteAsync(Song entity, CancellationToken
        cancellationToken = default)
            => throw new NotImplementedException();

        public async Task<Song> FirstOrDefaultAsync(Expression<Func<Song, bool>>
        filter, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();
    }
}
