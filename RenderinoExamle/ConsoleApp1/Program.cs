// See https://aka.ms/new-console-template for more information

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Client;
namespace C1;

public static class Programm
{
    public static async Task Main(string[] arg)
    {
        Console.WriteLine("Hello, World!");

        var client = new ApiClient(new HttpClient()
        {
            BaseAddress =new Uri("http://localhost:5012/")
        });
        var result = await client.GetNamesAsync(2);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        Console.ReadKey();
    }
}
