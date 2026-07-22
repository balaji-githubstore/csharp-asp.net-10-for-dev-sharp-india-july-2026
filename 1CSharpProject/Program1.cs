using System.Collections;
using CSharpProject;

//non-generic type 
ArrayList list=new ArrayList();
// list.Add(10); //boxing 
// list.Add(20.4);
// list.Add(90);
// list.Add(new Employee(3));

// string x= (string)list[2]; //unboxing
// System.Console.WriteLine(x.ToUpper());

// Employee e= (Employee)list[3]; //unboxing 
// e.allocateBonus();

//genric type 
List<string> colors = new List<string>();

colors.Add("red");
colors.Add("blue");

colors.Remove("blue");
colors.Insert(0, "yellow");

System.Console.WriteLine(colors.Count());

System.Console.WriteLine(colors[0].ToUpper());

List<string> techStack1 = new List<string> { "C#", "NET Core", "SQL Server" };

List<string> techStack2 = ["C#", "NET Core", "SQL Server", "Java", "Python"];

for (int i = 0; i < techStack2.Count(); i++)
{
    System.Console.WriteLine(techStack2[i]);
}

foreach (var x1 in techStack2)
{
    System.Console.WriteLine(x1.ToUpper());
}

techStack2.ForEach(x => System.Console.WriteLine(x));

List<int> numbers = [343, 3443, 343434, 3443];
numbers.ForEach(x => System.Console.WriteLine(x));


List<string> techStack4 = ["C#", "Net Core", "SQL Server", "Java", "Python", "Net Framework"];


var output = (from s in techStack4
              where s.ToLower().Contains("net")
              select s).ToList();

System.Console.WriteLine(output[0]);
output.ForEach(x => System.Console.WriteLine(x));

var output1 = techStack4.AsParallel().Where(x => x.ToLower().Contains("net")).ToList();

System.Console.WriteLine(output1[0]);
output1.ForEach((string x) => System.Console.WriteLine(x));



List<int> numbers1 = [343, 3443, 343434, 3443];

 void demo(int x)
{
    System.Console.WriteLine(x);
}

numbers.ForEach(a=>System.Console.WriteLine(a));


var output3 = numbers.Where(x => x > 400).ToList();

output3.ForEach(x => System.Console.WriteLine(x));

//
bool check(int x)
{
    return x > 400;
}
var output4 = numbers.Where(check).Distinct().ToList();

var sum = numbers1.Sum();
System.Console.WriteLine(sum);

System.Console.WriteLine(techStack4.Count());
System.Console.WriteLine(techStack4.Count(x => x.Contains("Net")));

//FirstOrDefault --> Returns the first element of a collection, or the first element that satisfies a condition.
//First --> Returns the first element of a collection, if nothing matches throw error 
var output5 = techStack4.FirstOrDefault(x => x.Contains("Net"));

//single --> should be only one item match in collection.  If Single() found no elements or more than one elements in the collection then throws
//single or default --> should be only one item match in collection. If Single() found no elements, return null 

System.Console.WriteLine(techStack4.Contains("C#"));

//sql inner join 

var studentList = new[] {
    new { StudentID = 1, StudentName = "John", StandardID =1 },
    new { StudentID = 2, StudentName = "Moin", StandardID =1 },
    new { StudentID = 3, StudentName = "Bill", StandardID =2 },
    new { StudentID = 4, StudentName = "Ram" , StandardID =2 },

};

var standardList = new[] {
    new { StandardID = 1, StandardName="Standard 1"},
    new { StandardID = 2, StandardName="Standard 2"},
    new { StandardID = 3, StandardName="Standard 3"}
};

var outputz=studentList.Join(standardList,
s=>s.StudentID,
x=>x.StandardID,

(s,x)=> new {id=s.StudentID,name=s.StudentName,StandardName=x.StandardName}
);

System.Console.WriteLine(outputz);



//firstordefault
//remove
//removeall


//skip