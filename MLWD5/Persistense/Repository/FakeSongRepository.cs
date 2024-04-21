using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistense.Repository
{
    internal class FakeSongRepository
    {
        List<Song> _songs = new List<Song>();
        public FakeSongRepository()
        {
            Song song1 = new Song("Imagine", "A beautiful song by John Lennon", "Imagine there's no heaven...", 1);
            song1.AddSinger(1);

            _songs.Add(song1);

            Song song2 = new Song("Bohemian Rhapsody", "Iconic song by Queen", "Is this the real life...", 2);
            song2.AddSinger(2);

            _songs.Add(song2);

            Song song3 = new Song("Rolling in the Deep", "Powerful song by Adele", "There's a fire starting in my heart...", 3);
            song3.AddSinger(3);

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

        Task<IReadOnlyList<Song>> ListAsync(Expression<Func<Song, bool>>
        filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<Song, object>>[]?
        includesProperties)
            => throw new NotImplementedException();

        Task AddAsync(Song entity, CancellationToken cancellationToken
        = default)
            => throw new NotImplementedException();

        Task UpdateAsync(Song entity, CancellationToken
        cancellationToken = default)
            => throw new NotImplementedException();

        Task DeleteAsync(Song entity, CancellationToken
        cancellationToken = default)
            => throw new NotImplementedException();

        Task<Song> FirstOrDefaultAsync(Expression<Func<Song, bool>>
        filter, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();
    }
}
