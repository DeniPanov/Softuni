namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;

    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movieDtos = JsonConvert.DeserializeObject<ImportMovieDto[]>(jsonString);
            var result = new StringBuilder();

            var titles = new List<string>();
            var validMovies = new List<Movie>();

            foreach (var dto in movieDtos)
            {
                if (IsValid(dto) == false || titles.Contains(dto.Title))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                titles.Add(dto.Title);

                Movie movie = new Movie
                {
                    Title = dto.Title,
                    Genre = Enum.Parse<Genre>(dto.Genre, true),
                    Duration = dto.Duration,
                    Rating = dto.Rating,
                    Director = dto.Director
                };

                validMovies.Add(movie);
                result.AppendLine(string.Format(
                    SuccessfulImportMovie,
                    movie.Title,
                    movie.Genre,
                    movie.Rating.ToString("f2")));
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallDtos = JsonConvert.DeserializeObject<ImportHallDto[]>(jsonString);

            var result = new StringBuilder();

            foreach (var dto in hallDtos)
            {
                if (IsValid(dto) == false || dto.Seats <= 0)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Hall hall = new Hall
                {
                    Name = dto.Name,
                    Is3D = dto.Is3D,
                    Is4Dx = dto.Is4Dx,
                };

                context.Halls.Add(hall);

                hall.Seats = new List<Seat>();

                for (int i = 0; i < dto.Seats; i++)
                {
                    Seat seat = new Seat
                    {
                        HallId = hall.Id
                    };

                    hall.Seats.Add(seat);
                }

                var projectionType = GetProjectionType(dto);

                result.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, projectionType, hall.Seats.Count));
            }

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProjectionDto[]),
                new XmlRootAttribute("Projections"));

            var projectionDtos = (ImportProjectionDto[])
                serializer.Deserialize(new StringReader(xmlString));

            var result = new StringBuilder();

            foreach (var dto in projectionDtos)
            {
                bool validateIds = ValidateHallIdAndMovieId(context, dto);

                if (IsValid(dto) == false || validateIds == false)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }
                
                Projection projection = new Projection
                {
                    MovieId = dto.MovieId,
                    HallId = dto.HallId,
                    DateTime = DateTime.ParseExact(dto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                context.Projections.Add(projection);

                result.AppendLine(string.Format(
                    SuccessfulImportProjection,
                    projection.Movie.Title, 
                    projection.DateTime.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture)));
            }

            context.SaveChanges();

            return result.ToString().TrimEnd();
        }


        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);

            return isValid;
        }

        private static string GetProjectionType(ImportHallDto dto)
        {
            string projType = "Normal";

            if (dto.Is3D == true && dto.Is4Dx == true)
            {
                projType = "4Dx/3D";
            }
            else if (dto.Is4Dx == true)
            {
                projType = "4Dx";
            }
            else if (dto.Is3D == true)
            {
                projType = "3D";
            }

            return projType;
        }

        private static bool ValidateHallIdAndMovieId(CinemaContext context, ImportProjectionDto dto)
        {
            bool validHallAndMovieIds = true;

            var validHallId = context.Halls.FirstOrDefault(h => h.Id == dto.HallId);
            var validMovieId = context.Movies.FirstOrDefault(m => m.Id == dto.MovieId);

            if (validHallId == null || validMovieId == null)
            {
                validHallAndMovieIds = false;
            }

            return validHallAndMovieIds;
        }
    }
}
