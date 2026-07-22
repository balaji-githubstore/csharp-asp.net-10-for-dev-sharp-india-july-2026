using DemoProject.Pages;
using DemoProject.Services;

namespace BooksManagement.Test;

public class  BookServiceTests
{
    [Theory]
    [InlineData(500, 0)]
    [InlineData(1000, 100)]
    [InlineData(2000, 200)]
    public void CalculateDiscount_ReturnsExpectedValue(decimal price, decimal expected)
    {

        // var model =new IndexModel();
        // Arrange
        var service = new BookService();

        // Act
        var discount = service.CalculateDiscount(price);

        // Assert
        Assert.Equal(expected, discount);
    }
}
