using MatchingMicroserviceAPI.Data;
using MatchingMicroserviceAPI.IRepository;
using MatchingMicroserviceAPI.MatchingApi;
using MatchingMicroserviceAPI.Repository;
using MatchingMicroserviceAPI.Services;
using MatchingMicroserviceAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMatchingRepository, MatchingRepository>();

builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<IMatchingService, MatchingService>();


// Configure HttpClient for UserService
builder.Services.AddHttpClient<IUsersService, UsersService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:44347/");
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

ApiExtensions.MapMatchesApiExtensions(app);

app.Run();