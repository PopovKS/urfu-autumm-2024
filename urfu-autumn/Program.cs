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

builder.Services.RegisterRepository<ICustomerRepository, CustomerRepository>();
builder.Services.RegisterRepository<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();

public class CustomerQuery
{
    private readonly IReadOnlyRepository<Customer> _readOnlyRepository;
    private readonly IOrderRepository _orderRepository;


    public CustomerQuery(IReadOnlyRepository<Customer> readOnlyRepository, IOrderRepository orderRepository)
    {
        _readOnlyRepository = readOnlyRepository;
        _orderRepository = orderRepository;
    }
}