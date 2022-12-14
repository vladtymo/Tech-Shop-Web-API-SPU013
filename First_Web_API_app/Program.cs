using BusinessLogic;
using BusinessLogic.Interfaces;
using Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionStr = builder.Configuration.GetConnectionString("AzureDb");

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<TechShopDbContext>(options => options.UseSqlServer(connectionStr));

// add Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<TechShopDbContext>()
    .AddDefaultTokenProviders();

// add custom services
builder.Services.AddScoped<ILaptopService, LaptopService>();
builder.Services.AddScoped<IAccountService, AccountService>();

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

app.UseCors(
    builder => builder
        .WithOrigins("http://localhost:4200", "https://gentle-sand-0fc9a2010.2.azurestaticapps.net")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
