using System;
using System.ComponentModel.DataAnnotations;
namespace BookManagementWebAppRazor.Models;
public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }

    [Required]
    public string Author { get; set; } = string.Empty;
    
    [property: Range(1000, 2000)]
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }

}
