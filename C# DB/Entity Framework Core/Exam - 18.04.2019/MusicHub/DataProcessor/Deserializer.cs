namespace MusicHub.DataProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;

    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<ImportWriterDto[]>(jsonString);

            var result = new StringBuilder();
            var writers = new List<Writer>();

            foreach (var dto in writersDto)
            {
                if (IsValid(dto) == false)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Writer writer = new Writer
                {
                    Name = dto.Name,
                    Pseudonym = dto.Pseudonym
                };

                writers.Add(writer);
                result.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducerAlbumDto[]>(jsonString);

            var result = new StringBuilder();
            var producers = new List<Producer>();

            foreach (var dto in producersDto)
            {
                if (IsValid(dto) == false || dto.Albums.All(IsValid) == false)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Producer producer = new Producer
                {
                    Name = dto.Name,
                    Pseudonym = dto.Pseudonym,
                    PhoneNumber = dto.PhoneNumber,
                };

                foreach (var album in dto.Albums)
                {
                    producer.Albums.Add(new Album
                    {
                        Name = album.Name,
                        ReleaseDate = DateTime.ParseExact(album.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    });
                }

                producers.Add(producer);

                if (producer.PhoneNumber == null)
                {
                    result.AppendLine(string.Format(
                        SuccessfullyImportedProducerWithNoPhone,
                        producer.Name,
                        producer.Albums.Count));
                }

                else
                {
                    result.AppendLine(string.Format(
                        SuccessfullyImportedProducerWithPhone,
                        producer.Name,
                        producer.PhoneNumber,
                        producer.Albums.Count));
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportSongDto[]),
                new XmlRootAttribute("Songs"));

            var songDtos = (ImportSongDto[])serializer.Deserialize(new StringReader(xmlString));

            var validSongs = new List<Song>();
            var result = new StringBuilder();

            foreach (var dto in songDtos)
            {
                if (IsValid(dto) == false)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidEnum = Enum.TryParse<Genre>(dto.Genre, out Genre genre);
                var duration = TimeSpan.ParseExact(dto.Duration, "c", CultureInfo.InvariantCulture);
                var albumId = context.Albums.FirstOrDefault(a => a.Id == dto.AlbumId);
                var writerId = context.Writers.FirstOrDefault(w => w.Id == dto.WriterId);

                if (isValidEnum == false || duration == null
                    || albumId == null || writerId == null)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Song song = new Song
                {
                    Name = dto.Name,
                    Duration = duration,
                    CreatedOn = DateTime.ParseExact(dto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = genre,
                    AlbumId = dto.AlbumId,
                    WriterId = dto.WriterId,
                    Price = dto.Price
                };

                validSongs.Add(song);
                result.AppendLine(string.Format(
                    SuccessfullyImportedSong,
                    song.Name,
                    song.Genre,
                    song.Duration));
            }

            context.Songs.AddRange(validSongs);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportPerformersDto[]),
                new XmlRootAttribute("Performers"));

            var performersDto = (ImportPerformersDto[])
                serializer.Deserialize(new StringReader(xmlString));

            var validPerformers = new List<Performer>();

            var result = new StringBuilder();

            foreach (var dto in performersDto)
            {
                if (IsValid(dto) == false)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Performer performer = new Performer
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    NetWorth = dto.NetWorth,
                };

                int validSongIdsCount = context.Songs.Count(x => dto.PerformersSongs.Any(s => s.SongId == x.Id));
                bool isValidSongId = true;

                foreach (var importPerformersSongsDto in dto.PerformersSongs)
                {
                    if (validSongIdsCount != dto.PerformersSongs.Length)
                    {
                        result.AppendLine(ErrorMessage);
                        isValidSongId = false;
                        break;
                    }

                    performer.PerformerSongs.Add(new SongPerformer
                    {
                        SongId = importPerformersSongsDto.SongId
                        //performerId?
                    });
                }

                if (isValidSongId == false)
                {
                    continue;
                }

                validPerformers.Add(performer);
                result.AppendLine(string.Format(
                    SuccessfullyImportedPerformer,
                    performer.FirstName,
                    performer.PerformerSongs.Count));
            }

            context.Performers.AddRange(validPerformers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

            return isValid;
        }
    }
}