using HotelsApi.Context;
using Microsoft.EntityFrameworkCore;
using HotelsApi.Repositories;
using HotelsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Auto Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Services
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IBarangayService, BarangayService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IStateService, StateService>();

// Repositories
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IBarangayRepository, BarangayRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();

// Database Configuration
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
string connectionString = "server=localhost; port=3306; database=HotelsApi; user=root; password=123456789; SslMode=Required;Allow User Variables=true;";

builder.Services.AddDbContext<DatabaseContext>(
            dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion).EnableDetailedErrors()
        );

builder.Logging.AddConsole();

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
