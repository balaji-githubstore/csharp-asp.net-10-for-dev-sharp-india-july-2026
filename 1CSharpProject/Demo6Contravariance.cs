Action<Animal> action = a =>
{
    Console.WriteLine("Animal1"+a);
};

// Animal animal = new Dog();      // ✔ Everyone understands

// Print(new Dog());               // ✔ Same concept

// Action<Animal> action = Print;  // Delegate to the same method

// Action<Dog> dogAction = action; // ✔ Contravariance


// dog accepts = animal (contravariance)
Action<Dog> dogAction = action;

dogAction(new Dog());

class Animal { }

class Dog : Animal { }



/*
Without Contravariance
class Animal { }
class Dog : Animal { }
class Cat : Animal { }


You might write:

void ProcessDog(Dog dog)
{
}

void ProcessCat(Cat cat)
{
}


With Contravariance
Write one generic method:

void ProcessAnimal(Animal animal)
{
    Console.WriteLine("Processing Animal");
}

This single method can process:

Dog
Cat
Horse

No duplicate code.



Example:
void Log(object obj)
{
    Console.WriteLine(obj);
}

Since everything in C# inherits from object, the same method can log:

Log("Hello");
Log(100);
Log(DateTime.Now);

*/