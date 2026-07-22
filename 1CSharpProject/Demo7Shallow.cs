using System;

class Address
{
    public string City { get; set; }
}

class Student : ICloneable
{
    public string Name { get; set; }

    public Address Address { get; set; }

    public object Clone()
    {
        return MemberwiseClone();   // Shallow Copy
    }

    // for deep copy
    //  public object Clone()
    // {
    //     return new Student
    //     {
    //         Name = this.Name,
    //         Address = new Address
    //         {
    //             City = this.Address.City
    //         }
    //     };
    // }
}

class Program
{
    static void Main()
    {
        Student s1 = new Student
        {
            Name = "Balaji",
            Address = new Address
            {
                City = "Chennai"
            }
        };

        Student s2 = (Student)s1.Clone();
        s2.Name="john";
        s2.Address.City = "Bangalore";

        Console.WriteLine(s1.Name);
        Console.WriteLine(s2.Name);

        Console.WriteLine(s1.Address.City);
        Console.WriteLine(s2.Address.City);
    }
}