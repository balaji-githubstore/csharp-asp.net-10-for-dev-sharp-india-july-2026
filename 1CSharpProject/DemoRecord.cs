var c1 = new Customer(10, "jack");
var c2 = new Customer(11, "peter");
System.Console.WriteLine(c1==c2);
//create, put 
//new object for record and replace 

//only for patch 
c2=c2 with
{
    id=10,
    name="jack"
};

System.Console.WriteLine(c1==c2);

List<Customer> customers = [c1, c2];
public record Customer(int id, string name)
{
    
};