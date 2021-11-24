var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<HelloService>(new HelloService());

builder.Services.AddSingleton<DapperRepository<Employee>>(s =>
    new DapperRepository<Employee>(
        builder.Configuration.GetConnectionString("ChinnokConnectionString")));

var app = builder.Build();

var customers = new List<Customer>();
customers.Add(new Customer { Id = 1, Name = "Isadora Jarr", Email = "isadora@jarr.com" });
customers.Add(new Customer { Id = 2, Name = "Mike Easter", Email = "mike@easter.com" });
customers.Add(new Customer { Id = 3, Name = "Amanda Reckonwith", Email = "amanda@reckonwith.com" });

app.MapGet("/", () => "Hello World!");

app.MapGet("/{Name}", (string Name) => $"Hello {Name}!");

app.MapGet("/hello", 
    (HttpContext context, HelloService helloService) => 
        helloService.SayHello(context.Request.Query["name"].ToString()));

app.MapGet("/customer", () => customers.First());

app.MapGet("/customers", () => {
    return customers;
});

app.MapPost("/customer", (Customer customer) => {
    customers.Add(customer);
});

app.MapDelete("/customer", (int Id) =>
{
    var customer = (from x in customers where x.Id == Id select x).FirstOrDefault();
    if (customer != null)
    {
        customers.Remove(customer);
    }
});

app.MapPut("/customer", (Customer customer) => {
    var cust = (from x in customers where x.Id == customer.Id select x).FirstOrDefault();  
    if (cust != null)
    {
        var index = customers.IndexOf(cust);
        customers[index] = customer;
    }
});

// Chinook Employees
app.MapGet("/employees",
    async (DapperRepository<Employee> EmployeeManager) => {
        return await EmployeeManager.GetAll();
    });

app.MapPost("/employees",
    async (Employee Employee, DapperRepository < Employee> EmployeeManager) => {
        await EmployeeManager.Insert(Employee);
    });

app.MapDelete("/employees", async (int EmployeeId, DapperRepository<Employee> EmployeeManager) =>
{
    var employees = await EmployeeManager.GetAll();
    var employee = (from x in employees where x.EmployeeId == EmployeeId select x).FirstOrDefault();
    if (employee != null)
    {
        await EmployeeManager.Delete(employee);
    }
});

app.MapPut("/employees", async(Employee Employee, DapperRepository<Employee> EmployeeManager) => {
    var employees = (await EmployeeManager.GetAll()).ToList();
    var dbEmployee = (from x in employees where x.EmployeeId == Employee.EmployeeId select x).FirstOrDefault();
    if (dbEmployee != null) {
        await EmployeeManager.Update(Employee);
    }
});

app.Run();
