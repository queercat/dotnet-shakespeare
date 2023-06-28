using System.Text.Json;

public class QuoteService : IQuoteService
{
    private string[] _quotes = Array.Empty<string>();
    private string _path = String.Empty;

    public QuoteService(string path)
    {
        _path = path;

        var data = JsonSerializer.Deserialize<Dictionary<string, string[]>>(File.ReadAllText(_path));

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

    public string AddQuote(string quote)
    {
        this._quotes = this._quotes.Append(quote).ToArray();
        this.SaveQuotes();
        return quote;
    }

    private void SaveQuotes()
    {
        var data = new Dictionary<string, string[]>();
        data.Add("quotes", this._quotes);
        File.WriteAllText(_path, JsonSerializer.Serialize(data));
    }

    ~QuoteService()
    {
        this.SaveQuotes();
    }
}