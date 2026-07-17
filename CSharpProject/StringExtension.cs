
// using MyCustomExtensions;

// Calculator c=new Calculator();
// int a=c.WordCount(:)


namespace MyCustomExtensions
{
    // 1. Must be a static class
    public static class StringExtensions 
    {
        // 2. Must be a static method
        // 3. 'this' specifies that we are extending the 'string' type
        public static int WordCount(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            return text.Split(new[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }

    public static class CalculatorExtensions 
    {
        // 2. Must be a static method
        // 3. 'this' specifies that we are extending the 'string' type
        public static int WordCount(this Calculator text)
        {
            return 10;
        }
    }
}
