using System.Text.Json;

public class QuoteService : IQuoteService
{
    private string[] _quotes = Array.Empty<string>();

    public QuoteService(string path)
    {
        var data = JsonSerializer.Deserialize<Dictionary<string, string[]>>(File.ReadAllText(path));

        if (data == null || !data.ContainsKey("quotes"))
        {
            throw new Exception("Invalid quotes file.");
        }

        _quotes = data["quotes"];
    }

    public string GetQuote()
    {
        return _quotes[new Random().Next(0, _quotes.Length)];
    }
}