using System;
using Microsoft.AspNetCore.Mvc;

public class ShakespeareController
{
    private readonly string[] _quotes;

    public ShakespeareController(string[] quotes)
    {
        _quotes = quotes;
    }

    [HttpGet]
    public IActionResult getText()
    {
        var shakespeare = new Shakespeare();
        shakespeare.Text = _quotes[new Random().Next(0, _quotes.Length)];
        return new OkObjectResult(shakespeare);
    }
}