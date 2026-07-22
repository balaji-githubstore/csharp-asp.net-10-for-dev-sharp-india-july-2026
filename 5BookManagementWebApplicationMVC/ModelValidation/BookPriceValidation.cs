using System;
using System.ComponentModel.DataAnnotations;
using BookManagementWebApplication.Models;


namespace GameStore.API.ModelValidation;

public class BookPriceValidationAttribute : ValidationAttribute
{
    //for action genre, instead of 1000 to 2000, custom validating - 1000 to 1500 
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var book = validationContext.ObjectInstance as Book;

        if (!book.IsAvailable)
        {
            return new ValidationResult("Book should be available to change the price");
        }
        return ValidationResult.Success;
    }
}
