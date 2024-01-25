namespace OrderService.Controllers.v1;

using OrderService.Domain.Orders.Features;
using OrderService.Domain.Orders.Dtos;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;

[ApiController]
[Route("api/orders")]
[ApiVersion("1.0")]
public sealed class OrdersController: ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    

    /// <summary>
    /// Creates a new Order record.
    /// </summary>
    [HttpPost(Name = "AddOrder")]
    public async Task<ActionResult<OrderDto>> AddOrder([FromBody]OrderForCreationDto orderForCreation)
    {
        var command = new AddOrder.Command(orderForCreation);
        var commandResponse = await _mediator.Send(command);

        return CreatedAtRoute("GetOrder",
            new { orderId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Order by ID.
    /// </summary>
    [HttpGet("{orderId:guid}", Name = "GetOrder")]
    public async Task<ActionResult<OrderDto>> GetOrder(Guid orderId)
    {
        var query = new GetOrder.Query(orderId);
        var queryResponse = await _mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Orders.
    /// </summary>
    [HttpGet(Name = "GetOrders")]
    public async Task<IActionResult> GetOrders([FromQuery] OrderParametersDto orderParametersDto)
    {
        var query = new GetOrderList.Query(orderParametersDto);
        var queryResponse = await _mediator.Send(query);

        var paginationMetadata = new
        {
            totalCount = queryResponse.TotalCount,
            pageSize = queryResponse.PageSize,
            currentPageSize = queryResponse.CurrentPageSize,
            currentStartIndex = queryResponse.CurrentStartIndex,
            currentEndIndex = queryResponse.CurrentEndIndex,
            pageNumber = queryResponse.PageNumber,
            totalPages = queryResponse.TotalPages,
            hasPrevious = queryResponse.HasPrevious,
            hasNext = queryResponse.HasNext
        };

        Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return Ok(queryResponse);
    }


    /// <summary>
    /// Updates an entire existing Order.
    /// </summary>
    [HttpPut("{orderId:guid}", Name = "UpdateOrder")]
    public async Task<IActionResult> UpdateOrder(Guid orderId, OrderForUpdateDto order)
    {
        var command = new UpdateOrder.Command(orderId, order);
        await _mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Order record.
    /// </summary>
    [HttpDelete("{orderId:guid}", Name = "DeleteOrder")]
    public async Task<ActionResult> DeleteOrder(Guid orderId)
    {
        var command = new DeleteOrder.Command(orderId);
        await _mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
