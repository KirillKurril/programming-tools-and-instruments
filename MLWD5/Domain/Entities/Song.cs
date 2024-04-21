using MLWD5.Domain.Entities;

namespace Domain.Entities
{
    public class Song : Entity
    {
        public Song() { }

        public Song(string name = "not definded", string description = "not definded", string text = "not definded", int chartPosition = -1)
        {
            Name = name;
            Description = description;
            Text = text;
            ChartPosition = chartPosition;
        }

        public int ChartPosition { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }

        public int? SingerId { get; set; }
        public Singer? Singer { get; set; }

        public void AddSinger(int singerId)
            => SingerId = singerId;
        public void RemoveSinger()
            => SingerId = 0;
    }
}
