using System;
namespace CSharpProject;

class Animal
{
    public virtual void Sound()
    {
        System.Console.WriteLine("sound??");
    }

    public void OnlyAnimal()
    {
        System.Console.WriteLine("only animal");
    }
}

class Dog : Animal
{
    public override void Sound()
    {
        System.Console.WriteLine("bark");
    }

    public void OnlyDog()
    {
        System.Console.WriteLine("only dog");
    }
}



