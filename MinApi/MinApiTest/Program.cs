using System.Net.Http.Json;

Console.WriteLine("Press Enter to send a POST request");
Console.ReadLine();
using (var http = new HttpClient())
{
    string url = "https://localhost:7083/customer";
    var customer = new Customer("Carl Franklin", "carl@appvnext.com");
    await http.PostAsJsonAsync(url, customer);
    Console.WriteLine("Done!");
}
