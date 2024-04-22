using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLWD5.Application.SingerUseCases.Commands
{
    public sealed record DeleteSingerCommand(int Id) : IRequest<Singer>;
}
