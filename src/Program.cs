using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using src;
using src.Models;
using TodoApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepo<TodoItem>, Repo>();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("Server=tcp:winwiredb.database.windows.net,1433;Initial Catalog=winwiresqldb;Persist Security Info=False;User ID=winadminuser;Password=WinaAdminPassword01$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddScoped<IRepodb<WinWire, Contact>, WinWireRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7270","http://localhost:5118","https://win-wire-app.redgrass-633dc5ff.eastus.azurecontainerapps.io")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType));

app.UseAuthorization();

app.MapControllers();

app.Run();
