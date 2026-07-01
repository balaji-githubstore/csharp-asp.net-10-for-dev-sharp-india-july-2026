using System;
namespace CSharpProject;

public class Employee
{
    public string performance;
    private int _id;
    private string _name;
    private double _salary;
    public static string companyName;

    public Employee(int _id)
    {
       
        this._id = _id;
    }

    public Employee(int _id,string name)
    {
       
        this._id = _id;
        this.Name=name;
    }


    public int Id
    {
        get => _id;
        //write
        set
        {
            if (value > 100)
            {
                _id = value;
            }
            else
            {
                System.Console.WriteLine("id should be greater than 100");
            }
        }
    }

    public double Salary
    {
        get => _salary;
        set => _salary = value;
    }
    public string Name { get => _name; set => _name = value; }

    public void PrintEmployeeDetails()
    {
        Console.WriteLine(this.Id);
        Console.WriteLine(this.Name);
        Console.WriteLine(Salary);
        Console.WriteLine(Employee.companyName);
    }

    public void allocateBonus()
    {
        
        if (performance.ToLower().Equals("good"))
        {
            Salary = Salary + 5000;
        }
        else if (performance.ToLower().Equals("average"))
        {
            Salary += 2000;
        }
    }
}
