namespace TestDbClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AppContext db = new AppContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.Add(new Band("amogus"));
            db.SaveChanges();
            var b = db.Bands.First();
            var Singers = b.Singers;
            Singers.Add(new Singer("Amongus"));
            Singers.Add(new Singer("Abobus"));
            Singers.Add(new Singer("Asus"));
            db.SaveChanges();

            Band band = db.Bands.First();
            foreach (var singer in band.Singers)
                Console.WriteLine(singer.Name);

            band = db.Bands.First();
            band.AddMainFan("Jiji");
            db.SaveChanges();

            band = db.Bands.FirstOrDefault(b => b.Name == "amogus");
            string mainfanName = band.MainFan.Name;
            Console.WriteLine(mainfanName);

            List<Singer> singers = band.Singers;
            var s1 = singers.FirstOrDefault(s => s.Name == "Amongus");
            s1.AddSong("Плачу на техно");
            s1.AddSong("Вершки и корешки");
            s1.AddSong("Колхозный панк");

            var s2 = singers.FirstOrDefault(s => s.Name == "Abobus");
            s2.AddSong(s1.Songs[0]);
            s2.AddSong(s1.Songs[1]);
            s2.AddSong(s1.Songs[2]);

            var s3 = singers.FirstOrDefault(s => s.Name == "Asus");
            s3.AddSong("А МОЕЙ ЖЕНОЙ");
            s3.AddSong("НАКОРМИЛИ ТОЛПУ");
            s3.AddSong("МИРОВЫМ КУЛАКОМ РАСТОПТАЛИ ЕЙ ГРУДЬ");

            db.SaveChanges();

            List<Singer> huingers = db.Singers.ToList();
            foreach(var huinger in huingers)
            {
                Console.WriteLine($"Huinger: {huinger.Name}\nSongs:");
                foreach(var song in huinger.Songs)
                    Console.Write(song.Name + " ");
            }
        }
    }
}
