using AppModels.Mapper;
using AppServices.Services;
using AppServices.Validator;
using DomainServices.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<WarrenEverestContext>(
    options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomersServices, CustomersServices>();
builder.Services.AddTransient<ICustomerAppServices, CustomerAppServices>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CustomerCreateDto>, CustomerCreateDtoValidator>();
builder.Services.AddScoped<IValidator<CustomerUpdateDto>, CustomerUpdateDtoValidator>();
builder.Services.AddAutoMapper(Assembly.Load("AppServices"));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
