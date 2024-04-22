using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLWD5.Application.SingerUseCases.Queries
{
    public sealed record GetAllSingersRequest() : IRequest<IEnumerable<Singer>>;
}
