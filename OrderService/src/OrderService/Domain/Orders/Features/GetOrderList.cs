namespace OrderService.Domain.Orders.Features;

using OrderService.Domain.Orders.Dtos;
using OrderService.Domain.Orders.Services;
using OrderService.Exceptions;
using OrderService.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetOrderList
{
    public sealed record Query(OrderParametersDto QueryParameters) : IRequest<PagedList<OrderDto>>;

    public sealed class Handler : IRequestHandler<Query, PagedList<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public Handler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<PagedList<OrderDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = _orderRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToOrderDtoQueryable();

            return await PagedList<OrderDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}