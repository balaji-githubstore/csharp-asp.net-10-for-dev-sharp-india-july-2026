    using System;
    using BookManagementWebApplication.Models;

    namespace BookManagementWebApplication.Model;

    public static class BookRepository
    {
        private static readonly List<Book> _books = new()
        {
            new Book
            {
                Id = 1,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Price = 499,
                IsAvailable = true
            },
            new Book
            {
                Id = 2,
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt",
                Price = 599,
                IsAvailable = true
            },
            new Book
            {
                Id = 3,
                Title = "Head First C#",
                Author = "Andrew Stellman",
                Price = 799,
                IsAvailable = false
            }
        };

        // Get all books
        public static List<Book> GetAll()
        {
            return _books;
        }

        // Get book by Id
        public static Book? GetById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        // Add a new book
        public static void Add(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
        }

        // Update existing book
        public static void Update(int id, Book updatedBook)
        {
            var book = GetById(id);
            if (book != null)
            {
                book.Title = book.Title != updatedBook.Title ? updatedBook.Title : book.Title;
                book.Author = book.Author != updatedBook.Author ? updatedBook.Author : book.Author;
                book.Price = book.Price != updatedBook.Price ? updatedBook.Price : book.Price;
                book.IsAvailable = book.IsAvailable != updatedBook.IsAvailable ? updatedBook.IsAvailable : book.IsAvailable;
            }
        }

        // Delete book
        public static void Delete(int id)
        {
            var book = GetById(id);

            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
