using Microsoft.EntityFrameworkCore;
using APIChat.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionsString = builder.Configuration.GetConnectionString("CadastroChat");

// Add services to the container.
builder.Services.AddDbContextPool<CadastroContext>(option => option.UseSqlServer(connectionsString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
