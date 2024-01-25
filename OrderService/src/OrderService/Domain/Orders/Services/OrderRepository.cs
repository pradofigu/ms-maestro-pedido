namespace OrderService.Domain.Orders.Services;

using OrderService.Domain.Orders;
using OrderService.Databases;
using OrderService.Services;

public interface IOrderRepository : IGenericRepository<Order>
{
}

public sealed class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly OrderDbContext _dbContext;

    public OrderRepository(OrderDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
