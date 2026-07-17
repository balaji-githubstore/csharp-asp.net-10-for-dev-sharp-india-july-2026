using System;
namespace CSharpProject;

public class Calculator
{
    // public void Add(int a,int b)
    // {
    //     System.Console.WriteLine(a+b);
    // }
    public void Add(int a, int b, int c)
    {
        System.Console.WriteLine(a + b);
    }

    public void Add(int a, double b)
    {
        System.Console.WriteLine(a + b);
    }
    public void Add(double b, int a)
    {
        System.Console.WriteLine(a + b);
    }
}