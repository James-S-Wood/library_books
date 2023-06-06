using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    class Program
    {
        // The library stores a list of books
        static List<Book> library = new List<Book>();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to the Library System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Display Books");
                Console.WriteLine("3. Search Books");
                Console.WriteLine("4. Exit");

                int choice = GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        DisplayBooks();
                        break;
                    case 3:
                        SearchBooks();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static int GetMenuChoice()
        {
            Console.Write("Enter your choice: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void AddBook()
        {
            Console.WriteLine("Enter book title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter book author: ");
            string author = Console.ReadLine();

            // Create a new Book object and add it to the library
            Book book = new Book(title, author);
            library.Add(book);

            Console.WriteLine("Book added successfully!");
        }

        static void DisplayBooks()
        {
            Console.WriteLine("List of Books:");

            if (library.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            // Iterate over each book in the library and display its title and author
            foreach (Book book in library)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
            }
        }

        static void SearchBooks()
        {
            Console.WriteLine("Enter search term: ");
            string searchTerm = Console.ReadLine();

            List<Book> searchResults = new List<Book>();

            // Search for books matching the search term in their title or author
            foreach (Book book in library)
            {
                if (book.Title.Contains(searchTerm) || book.Author.Contains(searchTerm))
                {
                    searchResults.Add(book);
                }
            }

            Console.WriteLine("Search Results:");

            if (searchResults.Count == 0)
            {
                Console.WriteLine("No books found matching the search term.");
                return;
            }

            // Display the search results
            foreach (Book book in searchResults)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
            }
        }
    }

    // The Book class represents a book with a title and an author
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}
