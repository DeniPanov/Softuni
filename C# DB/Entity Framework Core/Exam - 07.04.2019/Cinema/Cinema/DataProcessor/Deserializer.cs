namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using System.Text;
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
            throw new NotImplementedException();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
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
    }
}