using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDbClient
{
    public class Singer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BandId { get; set; }
        public Band? Band { get; set; }
        public List<Song> Songs { get; set; } = [];
        public Singer(string name)
        { 
            Name = name;
            Songs = new List<Song>();
        }
        public void AddSong(string name)
            => Songs.Add(new Song(name));
        public void AddSong(Song song)
            => Songs.Add(song);

    }
}
