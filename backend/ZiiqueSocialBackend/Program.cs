using AutoMapper;
using Domain;
using Domain.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repo;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add Bearer token configuration
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Do not include a 'Bearer' prefix with the token",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddControllers();

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProfileRepo, ProfileRepo>();
builder.Services.AddScoped<IPostRepo, PostRepo>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPAuthRepo, PAuthRepo>();
builder.Services.AddScoped<IPAuthService, PAuthService>();

builder.Services.AddScoped<IRequestData, RequestData>();

var mapper = new MapperConfiguration(config =>
{
    config.CreateMap<ProfileDto, Domain.Profile>();
    config.CreateMap<Domain.Profile, ProfileDto>();
}).CreateMapper();

builder.Services.AddSingleton(mapper);


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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["KeyCloak:Issuer"];
        options.RequireHttpsMetadata = false; // Need to see if we can get a certificate to run keycloak on https
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["KeyCloak:Issuer"],
            ValidateLifetime = true
        };
    });
builder.Services.AddAuthorization();

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

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();

