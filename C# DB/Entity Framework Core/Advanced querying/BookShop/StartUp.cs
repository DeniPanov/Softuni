﻿namespace BookShop
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

                string input = Console.ReadLine();

                string result = GetBooksByCategory(db, input);

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
    }
}
