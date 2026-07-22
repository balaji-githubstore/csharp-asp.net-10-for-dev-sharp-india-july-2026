using System;
namespace CSharpProject;

class Father
{
    public int fAge=70;

    public Father(int f)
    {
        fAge=f;
        System.Console.WriteLine("father constructor");
    }

    public void FatherSytle()
    {
        Console.WriteLine("father style!!!!!");
    }
}

class Son : Father
{
    public int sAge=20;
    public Son(int f,int s):base(f)
    {
        sAge=s;
        System.Console.WriteLine("son constructor");
    }

    public void SonStyle()
    {
        Console.WriteLine("Son style");
    }
}

