using ListOfActivities.Models;
using Microsoft.EntityFrameworkCore;
using ListOfActivities.OperationFilter;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ActivitiesContext>(opt => opt.UseNpgsql(config.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen(c => c.OperationFilter<AddRequestHeaderParameter>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

