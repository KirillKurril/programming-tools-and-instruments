using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLWD5.Application.SingerUseCases.Commands
{
    public sealed record AddSingerCommand(int Id, string Name, int Age, string Biography, string PhotoRef) : IRequest<Singer>;
}
