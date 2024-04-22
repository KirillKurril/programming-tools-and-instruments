using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestDbClient
{
    public class Song
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public List<Singer> Singers { get; set; } = [];
        public Song(string name)
        {
            Name = name;
            Singers = new List<Singer>();
        }
    }
}
