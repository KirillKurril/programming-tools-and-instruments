using SQLite;
using MLWD.Entities;
using MLWD.Services;

namespace MLWD
{
    public class MuseumDataBase : IDbService<MuseumHall, Exhibit>
    {
        SQLiteConnection Database;
        string databasePath;

        public MuseumDataBase() => Init();

        public void Init()
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

        public IEnumerable<MuseumHall> GetHalls()
        {
            return Database.Table<MuseumHall>().ToList();
        }

        public IEnumerable<Exhibit> GetExhibitsByHall(int id)
        {
            return Database.Table<Exhibit>().Where(e => e.HallId == id).ToList();
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

            var savedHalls = GetHalls().ToList();

            var exhibits = new List<Exhibit>
            {
                new Exhibit { Name = "\"Guernica\" by Pablo Picasso", HallId = savedHalls[0].Id },
                new Exhibit { Name = "\"Las Meninas\" by Diego Velázquez", HallId = savedHalls[0].Id },
                new Exhibit { Name = "\"The Persistence of Memory\" by Salvador Dalí", HallId = savedHalls[0].Id },
                new Exhibit { Name = "\"The Third of May 1808\" by Francisco Goya", HallId = savedHalls[0].Id },
                new Exhibit { Name = "\"The Garden of Earthly Delights\" by Hieronymus Bosch", HallId = savedHalls[0].Id },

                new Exhibit { Name = "\"The Wanderer above the Sea of Fog\" by Caspar DavName Friedrich", HallId = savedHalls[1].Id },
                new Exhibit { Name = "\"The Garden of Earthly Delights\" by Hieronymus Bosch", HallId = savedHalls[1].Id },
                new Exhibit { Name = "\"The Scream\" by Edvard Munch", HallId = savedHalls[1].Id },
                new Exhibit { Name = "\"Portrait of Adele Bloch-Bauer I\" by Gustav Klimt", HallId = savedHalls[1].Id },
                new Exhibit { Name = "\"The Persistence of Memory\" by Salvador Dalí", HallId = savedHalls[1].Id },

                new Exhibit { Name = "\"The Last Supper\" by Leonardo da Vinci", HallId = savedHalls[2].Id },
                new Exhibit { Name = "\"The Birth of Venus\" by Sandro Botticelli", HallId = savedHalls[2].Id },
                new Exhibit { Name = "\"Mona Lisa\" by Leonardo da Vinci", HallId = savedHalls[2].Id },
                new Exhibit { Name = "\"The Creation of Adam\" by Michelangelo", HallId = savedHalls[2].Id },
                new Exhibit { Name = "\"The School of Athens\" by Raphael", HallId = savedHalls[2].Id },

            };

            Database.InsertAll(exhibits);


        }
    }
}