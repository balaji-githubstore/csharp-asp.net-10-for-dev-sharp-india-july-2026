namespace BooksManagement.Dtos;

public record UpdateBook(
    string? Title, 
    string? Author, 
    int? Year
    //it can be null
    );
