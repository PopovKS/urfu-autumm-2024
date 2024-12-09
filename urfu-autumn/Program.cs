using Microsoft.EntityFrameworkCore;
using UrfuAutumn.Core.Domain;
using UrfuAutumn.Core.Domain.Repositories;
using UrfuAutumn.Core.Domain.SharedKernel.Storage;
using UrfuAutumn.Infrastructure.DataStorage;
using UrfuAutumn.Infrastructure.DataStorage.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssemblyContaining<Program>();
});

builder.Services.AddDbContext<ServerDbContext>(config =>
{
    config.UseNpgsql(builder.Configuration.GetConnectionString("Server"));
    config.EnableSensitiveDataLogging();
});

builder.Services.AddControllers();

builder.Services.RegisterRepository<ICustomerRepository, CustomerRepository>();
builder.Services.RegisterRepository<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(x =>
{
    x.MapControllers();
});

app.UseHttpsRedirection();
app.Run();