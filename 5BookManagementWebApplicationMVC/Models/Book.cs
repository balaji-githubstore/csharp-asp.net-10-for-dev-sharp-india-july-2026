using System;
using System.ComponentModel.DataAnnotations;
using GameStore.API.ModelValidation;

namespace BookManagementWebApplication.Models;

public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }

    [Required]
    public string Author { get; set; } = string.Empty;

    [property: BookPriceValidation]
    [property: Range(1000, 2000)]
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }

}
