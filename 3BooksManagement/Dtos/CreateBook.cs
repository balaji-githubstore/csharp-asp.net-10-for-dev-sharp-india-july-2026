namespace BooksManagement.Dtos;

public record CreateBook(
    string Title,
    string Author,
    int Year
);
