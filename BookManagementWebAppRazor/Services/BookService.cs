public interface IBookService
{
    decimal CalculateDiscount(decimal price);
}

public class BookService : IBookService
{
    public decimal CalculateDiscount(decimal price)
    {
        if (price >= 1000)
            return price * 0.10m;

        return 0;
    }
}