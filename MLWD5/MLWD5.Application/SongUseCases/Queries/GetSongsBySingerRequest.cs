using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLWD5.Application.SongUseCases.Queries
{
    public sealed record GetSongsBySingerRequest(int SingerId) : IRequest<IEnumerable<Song>>;
}
