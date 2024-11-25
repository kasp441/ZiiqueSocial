using Microsoft.EntityFrameworkCore;
using Repo;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var envConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
if (!string.IsNullOrWhiteSpace(envConnectionString))
{
    connectionString = envConnectionString;
}

//add connection string here
builder.Services.AddDbContext<RepoContext>(options =>
{
    options.UseNpgsql("connectionString");
});

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var testGroup = app.MapGroup("/test");

testGroup.MapGet("/test", () => "Test");


app.Run();

