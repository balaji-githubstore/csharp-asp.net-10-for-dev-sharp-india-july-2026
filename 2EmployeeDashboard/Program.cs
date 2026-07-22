using System.Diagnostics.Tracing;
using System.Text.Json;
using EmployeeDashboard.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//create a List<Employee> 
List<Employee> employees = [new(101, "john", 5000), new(102, "peter", 8000), new(103, "jack", 9000)];

//context --> it's an object of HTTPContext class (it contains all details related to request and with that you can build response)
//terminal middleware
app.Run(async (HttpContext context) =>
{
    if (context.Request.Method == "GET")
    {
        if (context.Request.Path.StartsWithSegments("/"))
        {
            context.Response.ContentType="text/html";

            await context.Response.WriteAsync("Planning to design employee dashboard<br/>");
            await context.Response.WriteAsync($"{context.Request.Method}\n");
            await context.Response.WriteAsync($"{context.Request.Path}\n");
            await context.Response.WriteAsync($"{context.Request.Host}\n");
            await context.Response.WriteAsync($"<ul>");
            foreach (var key in context.Request.Headers.Keys)
            {
                await context.Response.WriteAsync($"<li>{key} {context.Request.Headers[key]}</li>");
            }
            await context.Response.WriteAsync($"</ul>");
        }
        else if (context.Request.Path.Equals("/employees"))
        {
            await context.Response.WriteAsync("Employee Details\n");
            //print all the employee details
            foreach (var emp in employees)
            {
                await context.Response.WriteAsync($"Employee  Id: {emp.Id}\n");
                await context.Response.WriteAsync($"Employee  Name: {emp.Name}\n");
                await context.Response.WriteAsync($"Employee  Salary: {emp.Salary}\n");
                await context.Response.WriteAsync($"--------------------------\n");
            }
        }
        else if (context.Request.Path.Equals("/emp"))
        {
            context.Response.Redirect("/employees");
        }
        else
        {
            context.Response.StatusCode = 404;
        }
    }
    else if (context.Request.Method == "POST")
    {
        if (context.Request.Path.StartsWithSegments("/employees"))
        {
            //path should be /employees
            //understand request body and add it to employee list
            var body = new StreamReader(context.Request.Body);
            var bodyString = await body.ReadToEndAsync();

            try
            {
                var ignorePropertyCase = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var newEmployee = JsonSerializer.Deserialize<Employee>(bodyString, ignorePropertyCase);

                if (newEmployee != null)
                {
                    employees.Add(newEmployee);
                }
                else
                {
                    await context.Response.WriteAsync($"Body is empty");
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync($"{ex.ToString()}");
            }
        }
    }
    else if (context.Request.Method == "PUT")
    {
        if (context.Request.Path.StartsWithSegments("/employees"))
        {
            //path should be /employees
            //understand request body and update  if employee exists
            var body = new StreamReader(context.Request.Body);
            var bodyString = await body.ReadToEndAsync();

            var ignorePropertyCase = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var updateEmployee = JsonSerializer.Deserialize<Employee>(bodyString, ignorePropertyCase);

            if (updateEmployee != null)
            {
                //employees list - use FirstOrDefault
                var empDetail = employees.FirstOrDefault(x => x.Id == updateEmployee.Id);
                if (empDetail != null)
                {
                    empDetail.Name = updateEmployee.Name;
                    empDetail.Salary = updateEmployee.Salary;
                }
                else
                {
                    await context.Response.WriteAsync($"Employee not exists {updateEmployee.Id}");
                }

            }
            else
            {
                await context.Response.WriteAsync($"Body is empty");
            }
        }
    }
    else if (context.Request.Method == "DELETE")
    {
        //Authorization - apikey validations
        //x-api-key = kite-delete-456

        //check request header for x-api-key = kite-delete-456 
        //if match --> delete and set status code as 204
        //if not match --> set status code as 401
        if (context.Request.Headers.TryGetValue("x-api-key", out var value))
        {
            if (value.Equals("kite-delete-456"))
            {
                var idToDelete = Convert.ToInt32(context.Request.Query["id"]);
                int itemDeleted = employees.RemoveAll(x => x.Id == idToDelete);
                if (itemDeleted == 0)
                {
                    await context.Response.WriteAsync($"Employee not exists {idToDelete}");
                    //404
                }
                else
                {

                    context.Response.StatusCode = 204;
                    // await context.Response.WriteAsync($"Employee Deleted");
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = 401;
                return;
            }
        }
        else
        {
            context.Response.StatusCode = 401;
            return;
        }
        //add delete using route parameter
    }
});

app.Run();