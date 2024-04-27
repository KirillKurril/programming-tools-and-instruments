namespace MLWD5.Domain.Entities
{
    public class Singer : Entity
    {
        public string? Name { get; set; }
        public int? Age {  get; set; }
        public string? Biography { get; set; }
        public string? PhotoSource { get; set; }
        public List<Song> Songs { get; set;} = new ();
        public Singer() { }

        public Singer(string name = "not definded",
            int age = -1, string biography = "not definded",
            string photoReference = "not definded")
        {
            Name = name;
            Age = age;
            Biography = biography;
            PhotoSource = photoReference;
        }

        public void ChangeInfo(string? name = null, int? age = null, string? biography = null, string? photoReference = null)
        {
            if (name != null)
                Name = name;
            if (age != null)
                Age = age;
            if (biography != null)
                Biography = biography;
            if(photoReference != null)
                PhotoSource = photoReference;
        }
        public void AddSong(Song song)
            => Songs.Add(song);
        public void AddSong(string songName)
           => Songs.Add(new Song(songName));

        public void SetId(int id)
            => Id = id;
        public void SetPhotoSource(string photoSource)
            => PhotoSource = photoSource;
    }
}
