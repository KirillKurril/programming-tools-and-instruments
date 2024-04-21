using MLWD5.Domain.Entities;

namespace Domain.Entities
{
    public class Singer : Entity
    {
        public string Name { get; set; }
        public string PhotoReference { get; set; }
        public List<Song> Songs { get; set;} = new ();
        public Singer() { }
        public Singer(string name = "not definded", string photoReference = "not definded")
        {
            Name = name;
            PhotoReference = photoReference;
        }
        public void AddSong(Song song)
            => Songs.Add(song);
        public void AddSong(string songName)
           => Songs.Add(new Song(songName));
    }
}
