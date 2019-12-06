namespace MusicHub.DataProcessor
{
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;

    using Data;
    using MusicHub.DataProcessor.ExportDtos;

    using Newtonsoft.Json;
    using System.IO;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price.ToString("f2"),
                        Writer = s.Writer.Name
                    })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(w => w.Writer)
                    .ToList(),

                    AlbumPrice = a.Price.ToString("f2")
                })
                .OrderByDescending(a => decimal.Parse(a.AlbumPrice))
                .ToList();

            string json = JsonConvert.SerializeObject(albums, Formatting.Indented);
            return json;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context
                .Songs
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new ExportSongDto
                {
                    Name = s.Name,
                    Writer = s.Writer.Name,
                    Performer = s.SongPerformers.
                            Select(p => $"{p.Performer.FirstName} {p.Performer.LastName}").FirstOrDefault(),
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.Performer)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportSongDto[]),
                new XmlRootAttribute("Songs"));

            var result = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            serializer.Serialize(new StringWriter(result), songs, namespaces);

            return result.ToString().TrimEnd();
        }
    }
}