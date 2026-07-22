using System.ComponentModel.DataAnnotations;

namespace BooksManagement.Dtos;

public record Book(
    [property:Required]
    int Id, string? Title, string? Author, int? Year);
