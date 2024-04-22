using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDbClient
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Singer> Singers{ get; set; }
        public MainFan? MainFan { get; set; }
        public Band(string name)
        {
            Name = name;
            Singers = new List<Singer>();
        }
        public void AddMainFan(string name)
            => MainFan = new MainFan(name); 
    }
}
