using Core.Interfaces.Repositories;
using Core.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
using InternetBank.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InternetBankDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InternetBankContext")));
builder.Services.AddScoped<ILoanLimitRepository, LoanLimitRepository>();

builder.Services.AddScoped<ILoanLimitService, LoanLimitService>();
builder.Services.AddScoped<ILoanService, LoanService>();
var app = builder.Build();

// Dependency Injection for Services
builder.Services.AddScoped<IUserService, UserService>();
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
