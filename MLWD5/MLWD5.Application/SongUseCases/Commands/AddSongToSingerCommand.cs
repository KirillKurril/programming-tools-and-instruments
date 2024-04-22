using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLWD5.Application.SongUseCases.Commands
{
    public sealed record AddSongToSingerCommand(int Id,
        string Name,
        string Description,
        string Text,
        int ChartPosition) : IRequest<Song>;
}
