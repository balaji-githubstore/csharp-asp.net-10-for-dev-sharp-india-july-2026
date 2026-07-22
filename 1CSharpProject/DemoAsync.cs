using System;

namespace CSharpProject;

public class DemoAysnc
{

    public async Task<string> GetHelloAsync()
    {
        for(int i=1;i<=10;i++)
        {
            System.Console.WriteLine(i);
            await Task.Delay(2000);
        }
        return "Hello";
    }

    public async Task Method1()
    {
        System.Console.WriteLine("method 1");
        await Task.Delay(2000);
        throw new Exception("Exception in method 1");
    }

    public async Task Method2()
    {
        System.Console.WriteLine("method 2");
        await Task.Delay(1000);
        throw new Exception("Exception in method 2");
    }

    public void M1()
    {
        
    }

    public void M2()
    {
        
    }

}
