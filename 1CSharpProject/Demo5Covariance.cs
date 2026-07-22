Dog dog = new Dog();

Animal animal = dog;   // Covariance

animal.Eat();


class Animal
{
    public void Eat() => Console.WriteLine("Eating");
}

class Dog : Animal
{
    public void Bark() => Console.WriteLine("Barking");
}

