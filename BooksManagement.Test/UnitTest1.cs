namespace BooksManagement.Test;
//Moq --> mock property, method 
public class UnitTest1
{
    [Fact]
    public void FirstTest()
    {
        System.Console.WriteLine("fact");
    }

    [InlineData(2, 3, 15)]
    [InlineData(5, 5, 10)]
    [InlineData(10, 20, 30)]
    [Theory]
    public void Add_Test1(int a, int b, int expected)
    {
        Assert.Equal(expected, a + b);
    }

    public static IEnumerable<object[]> TestData =>
       new List<object[]>
       {
            new object[] {2, 3, 5},
            new object[] {5, 5, 10},
            new object[] {10, 20, 30}
       };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Add_Test(int a, int b, int expected)
    {
        Assert.Equal(expected, a + b);
    }

    // [Fact] is used for a single test with no input parameters. It runs once.
// [Theory] is used for a parameterized test. It accepts input from InlineData, MemberData,
}
