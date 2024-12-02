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
builder.Services.AddScoped<IProfileRepo, ProfileRepo>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var envConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
if (!string.IsNullOrWhiteSpace(envConnectionString))
{
    connectionString = envConnectionString;
}

//add connection string here
builder.Services.AddDbContext<RepoContext>(options =>
{
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("ZiiqueSocialBackend"));
});

var app = builder.Build();

//apply migrations if any
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RepoContext>();

    if (context.Database.GetPendingMigrations != null)
    {
        context.Database.Migrate();

    }
}

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

