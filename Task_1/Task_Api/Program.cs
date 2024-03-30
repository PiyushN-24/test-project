using Task_Api.Interface;
using Task_Api.Repository;
using Task_Api.Service;
using Task_Api.ServiceInterface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployee, Employee>();

builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICity, City>();

// Add services to the container.

builder.Services.AddControllers();

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
