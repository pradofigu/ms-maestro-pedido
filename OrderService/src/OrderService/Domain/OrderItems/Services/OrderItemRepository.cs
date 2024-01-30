namespace OrderService.Domain.OrderItems.Services;

using OrderService.Domain.OrderItems;
using OrderService.Databases;
using OrderService.Services;

public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
}

public sealed class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    private readonly OrderDbContext _dbContext;

    public OrderItemRepository(OrderDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
