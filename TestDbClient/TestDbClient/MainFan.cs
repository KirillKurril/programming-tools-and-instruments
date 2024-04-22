using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDbClient
{
    public class MainFan
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public int BandId { get; set; }
        public Band Band { get; set; } = null!;
        public MainFan(string name)
            => Name = name;
    }
}
