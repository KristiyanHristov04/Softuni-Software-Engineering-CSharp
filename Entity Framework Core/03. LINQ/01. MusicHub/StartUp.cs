using Microsoft.EntityFrameworkCore;
using MusicHub.Data;
using MusicHub.Initializer;
using System;
using System.Linq;
using System.Text;

namespace MusicHub
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            MusicHubDbContext context =
                  new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Test your solutions here
            string result = ExportAlbumsInfo(context, 9);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder output = new StringBuilder();

            var allAlbums = context.Albums
                .Include(a => a.Producer)
                .Include(a => a.Songs)
                .ThenInclude(s => s.Writer)
                .Where(a => a.ProducerId.Value == producerId)
                .ToArray()
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    AlbumSongs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        SongWriter = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.SongWriter)
                    .ToArray(),
                    TotalAlbumPrice = a.Price
                })
                .OrderByDescending(a => a.TotalAlbumPrice)
                .ToArray();


            foreach (var album in allAlbums)
            {
                int count = 1;
                output.AppendLine($"-AlbumName: {album.AlbumName}");
                output.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                output.AppendLine($"-ProducerName: {album.ProducerName}");
                output.AppendLine($"-Songs:");
                foreach (var song in album.AlbumSongs)
                {
                    output.AppendLine($"---#{count}");
                    output.AppendLine($"---SongName: {song.SongName}");
                    output.AppendLine($"---Price: {song.SongPrice:f2}");
                    output.AppendLine($"---Writer: {song.SongWriter}");
                    count++;
                }
                output.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:f2}");
            }

            return output.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
