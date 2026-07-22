using System;

namespace CSharpProject;


public class Box<T>
{
    public T? MyValues{get;set;}


    public void ShowMyValue()
    {
        System.Console.WriteLine(MyValues);
    }

    public static void Print<T1,T2>(T1 a,T2 b)
    {
        System.Console.WriteLine(a);
        System.Console.WriteLine(b);
    }
}