using Airport.Data;
using Airport.Data.Data_Structures_Imp.data_implement;
using Airport.Data.Repositories;
using FinalProj.Dal;
using Logic;
using Logic.Data_Structures;
using Logic.Data_Structures_Imp.data_implement;
using Logic.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AirportDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("FinalProjDb")));

// Add services to the container.

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(ITerminalRepository), typeof(TerminalRepository));
builder.Services.AddScoped(typeof(IFlightRepository), typeof(FlightRepository));
builder.Services.AddScoped(typeof(ILoggerRepository), typeof(LoggerRepository));
builder.Services.AddSingleton<IGraghAirport, AirportManager>();
builder.Services.AddSingleton<IGraphImp, GraphImp>();
builder.Services.AddSingleton(typeof(IGraph<>), typeof(Graph<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy(name: "AirportOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AirportOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
