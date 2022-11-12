using BusinessLogic;
using BusinessLogic.Interfaces;
using Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionStr = builder.Configuration.GetConnectionString("LocalDb");

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<TechShopDbContext>(options => options.UseSqlServer(connectionStr));

// add custom services
builder.Services.AddScoped<ILaptopService, LaptopService>();

// add AutoMapper service
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// add FluentValidator with validation classes
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
