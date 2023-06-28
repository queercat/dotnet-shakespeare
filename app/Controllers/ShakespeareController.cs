using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

[Route("api/shakespeare")]
[ApiController]
public class ShakespeareController : ControllerBase
{
    private readonly IQuoteService _quoteService;

    public ShakespeareController(IQuoteService quoteService)
    {
        _quoteService = quoteService;
    }

    [Route("text")]
    [HttpGet]
    public ActionResult getText()
    {
        Shakespeare shakespeare = new Shakespeare();
        shakespeare.Text = _quoteService.GetQuote();
        return Ok(shakespeare);
    }
}