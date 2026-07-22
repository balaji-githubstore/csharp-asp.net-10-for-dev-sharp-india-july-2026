using System;
using CSharpProject;


sbyte a=100; //8bits 
short b=100; //16bits 
int c=0;//32 bits 
long d=123234343433499L;

float e=10.2F; //32 bits 
double f=10.2; //64 bits 
decimal g=10.2M;

char letter='#'; //16 bits 
bool check=true; 

//non-predefined
string myName="jack"; //4*16 bits 

//
int[] arr=new int[5]; //5*32 bits of memory 
arr[0]=10;
arr[1]=20;
arr[2]=30;
arr[3]=40;
arr[4]=50; 
arr[4]=60; 

arr=new int[7];


double[] arr1=[1,2,4,5]; //4*64 bits 

string[] arr2=new string[3]; //8*16 bits 
arr2[0]="red";
arr2[1]="green";

Console.WriteLine(arr2[0]);

Console.WriteLine("Hello, World!");


double x=Math.Max(2,5);
Console.WriteLine(x);

Employee.companyName="Sharp Development";

Employee emp1=new Employee(102);
emp1.Id=101;
emp1.Name="john";
emp1.Salary=9000;
emp1.performance="Good";

Employee emp2=new Employee(101);
// emp2.id=-101;
emp2.Id=-100;
emp2.Name="kim";
emp2.Salary=10000;
emp2.performance="Average";

// Console.WriteLine(emp1.Id);
Console.WriteLine(emp1.Name);

// Console.WriteLine(emp2.id);
Console.WriteLine(emp2.Name);

// emp1=emp2;

// Console.WriteLine(emp1.id);
// Console.WriteLine(emp1.Name);

emp2.allocateBonus();
emp1.allocateBonus();

// Employee e=new Employee(101);




Son s=new Son(80,30);


System.Console.WriteLine(s.fAge);
System.Console.WriteLine(s.sAge);

s.FatherSytle();
s.SonStyle();

Calculator cal=new Calculator();
cal.Add((double)8,8);



Animal obj= new Dog();

obj.Sound();
obj.OnlyAnimal();

Dog dg= (Dog)obj;
dg.OnlyDog();



Person p=new PermanentEmoployee();
p.id=101;
p.name="jack";
p.CalculateSalary();

p=new ContractEmployee();
p.id=201;
p.name="saul";
p.CalculateSalary();


// IDriver driver=new ChromeBrowser();
// driver=new EdgeBrowser();

// driver.NavigateToURL();


// ChromeBrowser ch=new ChromeBrowser();
// ch.NavigateToURL();
// ch.GetTitle();
// ch.ExecuteScript();


List<Employee> employees=new List<Employee>();
employees.Add(emp1);
employees.Add(emp2);

List<Employee> lists=[new Employee(1,"jack"),new Employee(2,"peter"),new Employee(3,"kim")];

//create method return type bool and argument should be Employee
bool RunLogic(Employee employee)
{
    return employee.id>=150;
}

var seniorEmployees=employees.Where(x=>x.id<=150);
var seniorEmployees1=employees.Where(RunLogic);


// System.Console.WriteLine(emp1.id);

// System.Console.WriteLine(employees[0].id);


System.Console.WriteLine(emp1);
System.Console.WriteLine(emp1.GetHashCode());
System.Console.WriteLine(emp2.GetHashCode());