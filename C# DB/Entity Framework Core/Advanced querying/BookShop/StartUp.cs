namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                //int input = int.Parse(Console.ReadLine());

                int result = RemoveBooks(db);

                Console.WriteLine(result);
            }
        }

        //p01 - Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context
                .Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //p02 - Golden Books

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context
                .Books
                .OrderBy(b => b.BookId)
                .Where(b => b.EditionType.ToString().ToLower() == "gold" && b.Copies < 5000)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        //p03 - Books by Price

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            var result = new StringBuilder();

            foreach (var b in booksByPrice)
            {
                result.AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return result.ToString().TrimEnd();
        }

        //p04 - Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var notReleasedBooks = context
                .Books
                .OrderBy(b => b.BookId)
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, notReleasedBooks);
        }

        //p05 - Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> bookCategoriesInput = input
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            var booksToAdd = new List<string>();

            foreach (var bci in bookCategoriesInput)
            {
                var books = context
                    .Books
                    .Where(b => b.BookCategories.
                           Any(c => c.Category.Name.ToLower() == bci.ToLower()))
                    .Select(b => b.Title)
                    .ToList();

                booksToAdd.AddRange(books);
            }

            var resultToPrint = booksToAdd
                        .OrderBy(b => b);

            return string.Join(Environment.NewLine, resultToPrint);
        }

        //p06 - Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime currentDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksBeforeRelease = context
                .Books
                .Where(b => b.ReleaseDate < currentDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.ReleaseDate,
                    b.Price
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            var result = new StringBuilder();

            foreach (var book in booksBeforeRelease)
            {
                result.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return result.ToString().TrimEnd();
        }

        //p07 - Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            var result = new StringBuilder();

            foreach (var author in authors)
            {
                result.AppendLine(author.FullName);
            }

            return result.ToString().TrimEnd();
        }

        //p08 - Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine(book);
            }

            return result.ToString().TrimEnd();
        }

        //p09 - Book Search by Author 
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }

            return result.ToString().TrimEnd();
        }

        //p10 - Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToArray();

            return books.Length;
        }

        //p11 - Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books = context
                .Authors
                .Select(a => new
                {
                    TotalCopies = a.Books.Sum(b => b.Copies),
                    a.FirstName,
                    a.LastName
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToList();

            var result = new StringBuilder();

            foreach (var author in books)
            {
                result.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalCopies}");
            }

            return result.ToString().TrimEnd();
        }

        //p12 - Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            var result = new StringBuilder();

            foreach (var category in categories)
            {
                result.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
            }

            return result.ToString().TrimEnd();
        }

        //p13 - Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Top3Books = c.CategoryBooks
                            .OrderByDescending(b => b.Book.ReleaseDate)
                            .Take(3)
                            .Select(b => new
                            {
                                b.Book.Title,
                                ReleaseDate = b.Book.ReleaseDate.Value.Year
                            })
                            .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            var result = new StringBuilder();

            foreach (var category in categories)
            {
                result.AppendLine($"--{category.Name}");

                foreach (var book in category.Top3Books)
                {
                    result.AppendLine($"{book.Title} ({book.ReleaseDate})");
                }
            }

            return result.ToString().TrimEnd();
        }

        //p14 - Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var booksToUpdate = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //p15 - Remove Books 
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            int bookCount = booksToRemove.Count();

            context.RemoveRange(booksToRemove);

            context.SaveChanges();

            return bookCount;
        }
    }
}
