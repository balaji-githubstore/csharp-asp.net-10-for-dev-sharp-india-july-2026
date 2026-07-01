abstract class Person
{
    public int id;
    public string name;

    public Person()
    {
        System.Console.WriteLine("person constructor");
    }

    public void PrintEmployeeDetails()
    {
        System.Console.WriteLine(id);
        System.Console.WriteLine(name);
    }

    public abstract void CalculateSalary();
}

class PermanentEmoployee : Person
{
    public override void CalculateSalary()
    {
        System.Console.WriteLine(30*3000);
    }
}
class ContractEmployee : Person
{

    public override void CalculateSalary()
    {
        System.Console.WriteLine(8*300);
    }
}