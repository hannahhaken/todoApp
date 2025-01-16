using TodoApp.Api.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=Data/todoapp.db";
DatabaseInitializer.Initialize(connectionString);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();