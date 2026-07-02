
DemoAysnc demo = new DemoAysnc();

// Task<string> task1 = demo.GetHelloAsync();

// System.Console.WriteLine("connect to db and do some activity");
// System.Console.WriteLine("do some other work");
// System.Console.WriteLine("do some other work");
// System.Console.WriteLine("do some other work");

// System.Console.WriteLine("do some other work");

// string output = await task1;
// System.Console.WriteLine(output);

// await demo.Method1();
// await demo.Method2();

// //wait for all task to complete
// await Task.WhenAll(demo.Method1(), demo.Method2());
// //waitall()


// await Task.Run(() =>
// {
//     System.Console.WriteLine("runs in the background");
//     System.Console.WriteLine("runs in the background");
// });

// // Task.WaitAll()
// //helps to run sync methods parallel 
// Parallel.Invoke(demo.M1,demo.M2);

// Parallel.For(1,6,i=>System.Console.WriteLine(i));

// List<string> techStack2 = ["C#", "NET Core", "SQL Server", "Java", "Python"];

// Parallel.ForEach(techStack2,x=>{
//     System.Console.WriteLine(x);
//     System.Console.WriteLine(x.ToUpper());
//     });

//waitAll --> block the thread. making asyc to sync method 

//whenall - doesn't block the thread 

var task = Task.WhenAll(demo.Method1(), demo.Method2());
try
{
    await task;
}
catch
{
    if (task.Exception != null)
    {
        foreach (var ex in task.Exception.InnerExceptions)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}

// object a=10;

// if(a is int)
// {
//     int x= (int)a;
//     System.Console.WriteLine(x+x);
// }

// if(a is int i)
// {
//     System.Console.WriteLine(x+x);
// }


Stack<int> ints=new Stack<int>();

//FILO 
ints.Push(1);
ints.Push(2);


int x= ints.Peek();

int removed=ints.Pop();
System.Console.WriteLine(removed);


Box<int> box=new Box<int>();
box.MyValues=10;

box.ShowMyValue();

Box<int>.Print(1,"2");