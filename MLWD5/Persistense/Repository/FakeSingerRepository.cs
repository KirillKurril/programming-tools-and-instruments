using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistense.Repository
{
    public class FakeSingerRepository
    {
        List<Singer> _singers = new List<Singer>();
        public FakeSingerRepository()
        {
            Singer singer1 = new Singer("John Lennon", "john_lennon.jpg");
            singer1.AddSong("Imagine");
            singer1.AddSong("Imagine (Reprise)");

            _singers.Add(singer1);

            Singer singer2 = new Singer("Freddie Mercury", "freddie_mercury.jpg");
            singer2.AddSong("Bohemian Rhapsody");
            singer2.AddSong("Don't Stop Me Now");

            _singers.Add(singer2);

            Singer singer3 = new Singer("Adele", "adele.jpg");
            singer3.AddSong("Rolling in the Deep");
            singer3.AddSong("Someone Like You");

            _singers.Add(singer3);
        }

        public Task<Singer> GetByIdAsync(int id, CancellationToken
        cancellationToken = default,
        params Expression<Func<Singer, object>>[]?
        includesProperties)
            => throw new NotImplementedException();

        public async Task<IReadOnlyList<Singer>> ListAllAsync(CancellationToken
        cancellationToken = default)
            =>  await Task.Run(() => _singers);

        Task<IReadOnlyList<Singer>> ListAsync(Expression<Func<Singer, bool>>
        filter,
        CancellationToken cancellationToken = default,
        params Expression<Func<Singer, object>>[]?
        includesProperties)
            => throw new NotImplementedException();

        Task AddAsync(Singer entity, CancellationToken cancellationToken
        = default)
            => throw new NotImplementedException();

        Task UpdateAsync(Singer entity, CancellationToken
        cancellationToken = default)
            => throw new NotImplementedException();

        Task DeleteAsync(Singer entity, CancellationToken
        cancellationToken = default)
            => throw new NotImplementedException();

        Task<Singer> FirstOrDefaultAsync(Expression<Func<Singer, bool>>
        filter, CancellationToken cancellationToken = default)
            => throw new NotImplementedException();
    }
}
