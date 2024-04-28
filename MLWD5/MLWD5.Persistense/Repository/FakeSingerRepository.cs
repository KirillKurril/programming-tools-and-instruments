﻿using MLWD5.Domain.Entities;
using System.Linq.Expressions;

namespace Persistense.Repository
{
    public class FakeSingerRepository : IRepository<Singer>
    {
        List<Singer> _singers = new List<Singer>();
        public FakeSingerRepository()
        {
            Singer singer1 = new Singer("John Lennon");
            singer1.AddSong("Imagine");
            singer1.AddSong("Imagine (Reprise)");
            singer1.SetId(1);
            singer1.SetPhotoSource("C:/Uni/programming-tools-and-instruments/MLWD5/MLWD5.UI/Resources/Images/default_singer_photo.png");

            _singers.Add(singer1);

            Singer singer2 = new Singer("Freddie Mercury");
            singer2.AddSong("Bohemian Rhapsody");
            singer2.AddSong("Don't Stop Me Now");
            singer2.SetId(2);
            singer2.SetPhotoSource("C:/Uni/programming-tools-and-instruments/MLWD5/MLWD5.UI/Resources/Images/default_singer_photo.png");

            _singers.Add(singer2);

            Singer singer3 = new Singer("Adele");
            singer3.AddSong("Rolling in the Deep");
            singer3.AddSong("Someone Like You");
            singer3.SetId(3);
            singer3.SetPhotoSource("C:/Uni/programming-tools-and-instruments/MLWD5/MLWD5.UI/Resources/Images/default_singer_photo.png");

            _singers.Add(singer3);
        }

        public Task<Singer> GetByIdAsync(int id, CancellationToken
        cancellationToken = default,
        params Expression<Func<Singer, object>>[]?
        includesProperties)
            => throw new NotImplementedException();

        public async Task<IReadOnlyList<Singer>> ListAllAsync(CancellationToken
        cancellationToken = default)
            => await Task.Run(() => _singers);

        public async Task<IReadOnlyList<Singer>> ListAsync(Expression<Func<Singer, bool>>
        filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<Singer, object>>[]?
        includesProperties)
            => throw new NotImplementedException();

        public async Task AddAsync(Singer entity, CancellationToken cancellationToken
        = default)
            => throw new NotImplementedException();

        public async Task UpdateAsync(Singer entity, CancellationToken
        cancellationToken = default)
            => throw new NotImplementedException();

        public async Task DeleteAsync(Singer entity, CancellationToken
        cancellationToken = default)
            => throw new NotImplementedException();

        public async Task<Singer> FirstOrDefaultAsync(Expression<Func<Singer, bool>>
        filter, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();
    }
}