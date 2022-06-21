
using ICanHazDadJoke.NET;

namespace ProjectTemplate;


public class Program
{
    private static async Task<int> Main(string[] args)
    {
        var client = new DadJokeClient("A feeble dotnet project template example", "https://github.com/IntelliTect/");

        var joke = await client.GetRandomJokeStringAsync();

        Console.WriteLine(joke);

        return await Task.FromResult(0);
    }
}



