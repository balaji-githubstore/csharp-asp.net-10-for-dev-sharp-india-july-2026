namespace DemoProject.Services;

public class BookService
{
    public decimal CalculateDiscount(decimal price)
    {
        if (price >= 1000)
            return price * 0.10m;

        return 0;
    }
}