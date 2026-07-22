using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagement.Dtos;

public class BookDetail
{

    [FromRoute]
    public int Id { get; set; }

    [FromQuery]
    public string Name { get; set; }

    [FromHeader]
    public string Type { get; set; }

    [FromBody]
    public Book book { get; set; }
}
