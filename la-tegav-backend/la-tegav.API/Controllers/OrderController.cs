using la_tegav.API.Custom;
using la_tegav.Application.Dtos;
using la_tegav.Application.UseCases.OrderEntity.Commands.CreateOrder;
using la_tegav.Application.UseCases.OrderEntity.Queries.GetAllIncomingPerMonth;
using la_tegav.Application.UseCases.OrderEntity.Queries.GetAllOrders;
using la_tegav.Application.UseCases.OrderEntity.Queries.GetAllOrderStatus;
using la_tegav.Application.UseCases.OrderEntity.Queries.GetOrderById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace la_tegav.API.Controllers;

[Route("v1/api/[controller]")]
[ApiController]
public class OrderController : CustomReturnController
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateOrder", Name = "CreateOrder")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrderDto>> Create
    ([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
    {
        try
        {
            OrderDto response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpGet("GetAllOrders", Name = "GetAllOrders")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<OrderDto>> GetAllOrders(CancellationToken cancellationToken)
    {
        try
        {
            List<OrderDto> response = await _mediator.Send(new GetAllOrdersQuery(), cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpGet("GetOrderById", Name = "GetOrderById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<OrderDto>> GetOrderById(int Id, CancellationToken cancellationToken)
    {
        try
        {
            GetOrderByIdQuery orderCommand = new GetOrderByIdQuery { Id = Id };
            OrderDto response = await _mediator.Send(orderCommand, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpGet("GetAllOrderStatus", Name = "GetAllOrderStatus")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<OrderStatusDto>> GetAllOrderStatus(CancellationToken cancellationToken)
    {
        try
        {
            OrderStatusDto response = await _mediator.Send(new GetAllOrderStatusQuery(), cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpGet("GetAllIncomingPerMonth", Name = "GetAllIncomingPerMonth")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<OrderIncomingDto>> GetAllIncomingPerMonth(CancellationToken cancellationToken)
    {
        try
        {
            OrderIncomingDto response = await _mediator.Send(new GetAllIncomingPerMonthQuery(), cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }
}
