using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ShakespeareController : ControllerBase
{
    private const string Path = "/Data/quotes.json";
    private readonly string[] _quotes;

    public ShakespeareController()
    {
        _quotes = JsonSerializer.Deserialize(
            System.IO.File.ReadAllText(Path),
            typeof(string[])) as string[] ?? Array.Empty<string>();
    }

    [Route("text")]
    public ActionResult getText()
    {
        var shakespeare = new Shakespeare();
        shakespeare.Text = _quotes[new Random().Next(0, _quotes.Length)];
        return new OkObjectResult(shakespeare);
    }
}