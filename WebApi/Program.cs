using AppModels.Mapper.Customer;
using AppServices.Interfaces;
using AppServices.Services;
using AppServices.Validator;
using DomainServices.Interfaces;
using DomainServices.Services;
using EntityFrameworkCore.UnitOfWork.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using HostedServices;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WarrenEverestContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), contextLifetime: ServiceLifetime.Transient);
builder.Services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomerServices, CustomerServices>();
builder.Services.AddTransient<ICustomerAppServices, CustomerAppServices>();
builder.Services.AddTransient<IProductServices, ProductServices>();
builder.Services.AddTransient<IProductAppServices, ProductAppServices>();
builder.Services.AddTransient<ICustomerBankInfoServices, CustomerBankInfoServices>();
builder.Services.AddTransient<ICustomerBankInfoAppServices, CustomerBankInfoAppServices>();
builder.Services.AddTransient<IOrderServices, OrderServices>();
builder.Services.AddTransient<IOrderAppServices, OrderAppServices>();
builder.Services.AddTransient<IPortfolioProductServices, PortfolioProductServices>();
builder.Services.AddTransient<IPortfolioProductAppServices, PortfolioProductAppServices>();
builder.Services.AddTransient<IOrderServices, OrderServices>();
builder.Services.AddTransient<IPortfolioServices, PortfolioServices>();
builder.Services.AddTransient<IPortfolioAppServices, PortfolioAppServices>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CreateCustomer>, CustomerCreateDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateCustomer>, CustomerUpdateDtoValidator>();
builder.Services.AddAutoMapper(Assembly.Load("AppServices"));
builder.Services.AddUnitOfWork<WarrenEverestContext>(ServiceLifetime.Transient);
builder.Services.AddCronJob<ExecuteOrders>(config =>
{
    config.CronExpression = "0 10 * * *";
    config.TimeZoneInfo = TimeZoneInfo.Local;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();