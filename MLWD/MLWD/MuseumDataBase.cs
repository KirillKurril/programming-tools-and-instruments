using SQLite;
using MLWD.Entities;

namespace MLWD
{
    public class MuseumDataBase
    {
        SQLiteConnection Database;
        string databasePath;

        public MuseumDataBase()
        {
            databasePath = Path.Combine(FileSystem.AppDataDirectory, "MuseumDatabase.db3");

            if (File.Exists(databasePath))
            {
                File.Delete(databasePath);
            }

            databasePath = Path.Combine(FileSystem.AppDataDirectory, "MuseumDatabase.db3");

            Database = new SQLiteConnection(databasePath);
            Database.CreateTable<MuseumHall>();
            Database.CreateTable<Exhibit>();
            FullfillDataBase();
        }

        public List<MuseumHall> GetHalls()
        {
            return Database.Table<MuseumHall>().ToList();
        }

        public List<Exhibit> GetExhibitsByHallName(string hallName)
        {
            return Database.Table<Exhibit>().Where(e => e.HallName == hallName).ToList();
        }

        public void FullfillDataBase()
        {
            var Halls = new List<MuseumHall>
            {
                  new MuseumHall { Name = "Spain" },
                  new MuseumHall { Name = "Germany" },
                  new MuseumHall { Name = "Italy" }
            };
            Database.InsertAll(Halls);

            var savedHalls = GetHalls();

            var exhibits = new List<Exhibit>
            {
                new Exhibit { Name = "\"Guernica\" by Pablo Picasso", HallName = savedHalls[0].Name },
                new Exhibit { Name = "\"Las Meninas\" by Diego Velázquez", HallName = savedHalls[0].Name },
                new Exhibit { Name = "\"The Persistence of Memory\" by Salvador Dalí", HallName = savedHalls[0].Name },
                new Exhibit { Name = "\"The Third of May 1808\" by Francisco Goya", HallName = savedHalls[0].Name },
                new Exhibit { Name = "\"The Garden of Earthly Delights\" by Hieronymus Bosch", HallName = savedHalls[0].Name },

                new Exhibit { Name = "\"The Wanderer above the Sea of Fog\" by Caspar DavName Friedrich", HallName = savedHalls[1].Name },
                new Exhibit { Name = "\"The Garden of Earthly Delights\" by Hieronymus Bosch", HallName = savedHalls[1].Name },
                new Exhibit { Name = "\"The Scream\" by Edvard Munch", HallName = savedHalls[1].Name },
                new Exhibit { Name = "\"Portrait of Adele Bloch-Bauer I\" by Gustav Klimt", HallName = savedHalls[1].Name },
                new Exhibit { Name = "\"The Persistence of Memory\" by Salvador Dalí", HallName = savedHalls[1].Name },

                new Exhibit { Name = "\"The Last Supper\" by Leonardo da Vinci", HallName = savedHalls[2].Name },
                new Exhibit { Name = "\"The Birth of Venus\" by Sandro Botticelli", HallName = savedHalls[2].Name },
                new Exhibit { Name = "\"Mona Lisa\" by Leonardo da Vinci", HallName = savedHalls[2].Name },
                new Exhibit { Name = "\"The Creation of Adam\" by Michelangelo", HallName = savedHalls[2].Name },
                new Exhibit { Name = "\"The School of Athens\" by Raphael", HallName = savedHalls[2].Name },

            };

            Database.InsertAll(exhibits);


        }
    }
}