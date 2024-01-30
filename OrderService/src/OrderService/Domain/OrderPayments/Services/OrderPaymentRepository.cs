namespace OrderService.Domain.OrderPayments.Services;

using OrderService.Domain.OrderPayments;
using OrderService.Databases;
using OrderService.Services;

public interface IOrderPaymentRepository : IGenericRepository<OrderPayment>
{
}

public sealed class OrderPaymentRepository : GenericRepository<OrderPayment>, IOrderPaymentRepository
{
    private readonly OrderDbContext _dbContext;

    public OrderPaymentRepository(OrderDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
