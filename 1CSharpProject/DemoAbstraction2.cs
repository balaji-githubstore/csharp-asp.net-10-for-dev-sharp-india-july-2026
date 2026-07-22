interface IDriver
{
    void NavigateToURL();
    String GetTitle();
}
interface IScript
{
    void ExecuteScript();
     String GetTitle();
}
class ChromeBrowser : IDriver, IScript
{
    public ChromeBrowser()
    {
        System.Console.WriteLine("launch browser chrome");
    }

    public void ExecuteScript()
    {
        throw new NotImplementedException();
    }

    public string GetTitle()
    {
        return "chrome title";
    }

    public void NavigateToURL()
    {
        System.Console.WriteLine("navigate to url chrome");
    }



    //internal 

}

class EdgeBrowser : IDriver,IScript
{
       public EdgeBrowser()
    {
        System.Console.WriteLine("launch browser edge");
    }
    public void ExecuteScript()
    {
        throw new NotImplementedException();
    }

    public string GetTitle()
    {
        return "navigate to url edge";
    }

    public void NavigateToURL()
    {
        System.Console.WriteLine("navigate to url edge");
    }
}