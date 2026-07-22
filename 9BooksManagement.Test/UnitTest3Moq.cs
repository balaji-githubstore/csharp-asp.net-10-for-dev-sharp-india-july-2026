using Moq;
using Xunit;

public interface IBookRepository1
{
    int GetBookCount();
}

public class BookService1 : IBookRepository1
{
    private readonly IBookRepository1 _repository;

    public BookService1(IBookRepository1 repository)
    {
        _repository = repository;
    }

    public int GetBookCount()
    {
        return _repository.GetBookCount();
    }
}

public class BookServiceTests
{
    [Fact]
    public void GetBookCount_ReturnsExpectedValue()
    {
        // Arrange
        var mockRepo = new Mock<IBookRepository1>();

        mockRepo.SetupGet(x => x.GetBookCount())
                .Returns(25);

        var service = new BookService1(mockRepo.Object);

        // Act
        var result = service.GetBookCount();
        
        Assert.IsType<int>(result);

        // Assert
        Assert.Equal(25, result);
    }
}