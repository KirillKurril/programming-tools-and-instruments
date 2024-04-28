using Microsoft.Extensions.DependencyInjection;

namespace MLWD5.Aplication
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();

            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();

            for (int i = 1; i <= 10; i++)
            {
                //var singer = new Singer(i, $"Singer {i}", i * 10, $"Biography {i}", $"PhotoReference {i}");
                var singer = new Singer($"Singer {i}", i * 10, $"Biography {i}", $"PhotoReference {i}");
                singer.SetId(i);
                singer.SetPhotoSource("singer.png");

                for (int j = 1; j <= 3; j++)
                {
                    var song = new Song($"Song {j} by Singer {i}", $"Description {j}", $"Text {j}", i + j);
                    song.SetId(i * 100 + j);
                    song.SetPhotoSource("song.jpg");
                    song.AddToSinger(i);
                    singer.Songs.Add(song);
                    await unitOfWork.SongRepository.AddAsync(song);
                }

                await unitOfWork.SingerRepository.AddAsync(singer);
            }

            await unitOfWork.SaveAllAsync();
        }
    }
}