using AppModels.Mapper;
using AppServices.Services;
using AppServices.Validator;
using DomainServices.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICustomersServices, CustomersServices>();
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
