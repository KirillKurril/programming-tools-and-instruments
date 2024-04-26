using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MLWD5.Domain.Entities
{
    public class Song : Entity
    {
        public int? ChartPosition { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Text { get; set; }

        public int SingerId { get; set; }
        public Singer? Singer { get; set; }
        public Song() { }

        public Song(
            string name = "not definded", 
            string description = "not definded",
            string text = "not definded",
            int chartPosition = -1)
        {
            Name = name;
            Description = description;
            Text = text;
            ChartPosition = chartPosition;
        }
        public Song(string name, string description, string text, int chartPosition, int id)
        {
            Name = name;
            Description = description;
            Text = text;
            ChartPosition = chartPosition;
            Id = id;
        }

        public Song(string name, string description, string text, int chartPosition, int id, int singerId)
        {
            Name = name;
            Description = description;
            Text = text;
            ChartPosition = chartPosition;
            SingerId = singerId;
        }
        public void ChangeInfo(string? name = null,
            string? description = null,
            string? text = null,
            int? chartPosition = null)
        {
            if (name != null)
                Name = name;
            if(description != null)
                Description = description;
            if (text != null)
                Text = text;
            if (chartPosition != null)
                ChartPosition = chartPosition;
        }
        
        public void AddToSinger(int singerId)
            => SingerId = singerId;
        public void RemoveSinger()
            => SingerId = 0;
    }
}
