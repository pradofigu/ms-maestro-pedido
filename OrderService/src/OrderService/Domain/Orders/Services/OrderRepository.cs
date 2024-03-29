using Microsoft.EntityFrameworkCore;

namespace OrderService.Domain.Orders.Services;

using OrderService.Domain.Orders;
using OrderService.Databases;
using OrderService.Services;

public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<Order> GetByCorrelationIdAsync(Guid correlationId, CancellationToken cancellationToken = default);
}

public sealed class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly OrderDbContext _dbContext;

    public OrderRepository(OrderDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> GetByCorrelationIdAsync(Guid correlationId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Orders
            .Where(x => x.CorrelationId == correlationId)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }
}
