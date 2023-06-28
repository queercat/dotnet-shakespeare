using System.IO;

var builder = WebApplication.CreateBuilder(args);

var QUOTES_PATH = System.IO.Path.Combine(builder.Environment.ContentRootPath, "Data", "quotes.json");

// Inject the quote service.
builder.Services.AddSingleton<IQuoteService, QuoteService>(_ => new QuoteService(QUOTES_PATH));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
