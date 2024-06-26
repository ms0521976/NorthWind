using Microsoft.EntityFrameworkCore;
using NorthWind.Data;
using NorthWind.Repositories;
using NorthWindProject.Mappings;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddScoped<ICustomerRepository, SQLCustomerRepository>();
//DBContext DI
builder.Services.AddDbContext<NorthWindContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("NorthWindConnectionString")));

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
