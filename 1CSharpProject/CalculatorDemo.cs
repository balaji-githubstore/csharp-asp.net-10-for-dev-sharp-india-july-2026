using System;

namespace CSharpProject;

public delegate void CalculatorDelegate(int a, int b);

public delegate int NewDelegate(int a, int b);

public class CalculatorDemo
{
    public void Add(int a, int b)
    {
        System.Console.WriteLine(a + b);
    }

    public void Sub(int a, int b)
    {
        System.Console.WriteLine(a + b);
    }

    public static int Sum(int x, int y)
    {
        return x + y;
    }
}
public class Program
{
    public static void CustomRun(CalculatorDelegate del, int a, int b)
    {
        System.Console.WriteLine("check db before executing!!");

        del(a, b);

        System.Console.WriteLine("store the result in db");
    }

    public static void DemoRun(Action<int,int> a)
    {
        
    }
    static void Main(string[] args)
    {
        CalculatorDemo c = new CalculatorDemo();
        //    c.Add(2,2);
        CalculatorDelegate del = c.Add;
        del += c.Sub;
        // del(1,2);

        Program.CustomRun(c.Add, 1, 2);
        Program.CustomRun(c.Sub, 1, 2);

        Program.CustomRun((a, b) => System.Console.WriteLine(a * b), 2, 2);

        Program.CustomRun((a, b) =>
               {
                   System.Console.WriteLine(a * b);
                   System.Console.WriteLine(a * b);

               }, 2, 2);

        //  CalculatorDelegate del = c.Add;
        //         del +=c.Sub;
        //         del(1,2);


        NewDelegate d=CalculatorDemo.Sum;
        var x=d(1,1);

        Func<int,int,int> demo=CalculatorDemo.Sum;
        int x1=demo(1,1);

        Action<int,int> actionDel=c.Add;
        
    }
}




