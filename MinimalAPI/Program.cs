using MinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

var list = new List<Post>()
{
    new() { Id = 1, Title = "First Post", Content = "Hello World" },
    new() { Id = 2, Title = "Second Post", Content = "Hello Again" },
    new() { Id = 3, Title = "Third Post", Content = "Goodbye World" },
};

app.MapGet("/posts", () =>
{
    return list;
}).WithName("GetPosts")
.WithTags("Posts");

app.MapGet("/posts/{id}",(int id) =>
{
    var post = list.FirstOrDefault(f => f.Id == id);
    if(post == null)
        return Results.NotFound();
    return Results.Ok(post);
}).WithName("GetPost")
.WithTags("Posts");

app.MapPost("/posts", (Post post) =>
{
    list.Add(post);
    return Results.Created($"/posts/{post.Id}",post);
}).WithName("CreatePost")
.WithTags("Posts");

app.MapPut("/posts/{id}", (int id, Post post) =>
{
    var index = list.FindIndex(f => f.Id == id);
    if(index == -1)
        return Results.NotFound();
    
    list[index] = post;
    return Results.Ok(post);
    
}).WithName("UpdatePost")
.WithTags("Posts");

app.MapDelete("/posts/{id}", (int id) =>
{
    var post = list.FirstOrDefault(f => f.Id == id);
    if(post == null)
        return Results.NotFound();
    list.Remove(post);
    return Results.Ok();
}).WithName("DeletePost")
.WithTags("Posts");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
