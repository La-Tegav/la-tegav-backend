using la_tegav.API.Custom;
using la_tegav.Application.Dtos;
using la_tegav.Application.UseCases.OrderEntity.Commands.CreateOrder;
using la_tegav.Application.UseCases.OrderEntity.Queries.GetAllOrders;
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

    //[HttpGet("GetProductById", Name = "GetProductById")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //public async Task<ActionResult<ProductDto>> GetProductById(int Id, CancellationToken cancellationToken)
    //{
    //    try
    //    {
    //        var productCommand = new GetProductByIdQuery { Id = Id };
    //        var response = await _mediator.Send(productCommand, cancellationToken);
    //        return Ok(response);
    //    }
    //    catch (Exception ex)
    //    {
    //        return ResultHandler(ex);
    //    }
    //}

    //[HttpPut("UpdateProduct", Name = "UpdateProduct")]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesDefaultResponseType]
    //public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand, CancellationToken cancellationToken)
    //{
    //    try
    //    {
    //        await _mediator.Send(updateProductCommand, cancellationToken);
    //        return NoContent();
    //    }
    //    catch (Exception ex)
    //    {
    //        return ResultHandler(ex);
    //    }
    //}

    //[HttpDelete("DeleteProduct/{id}", Name = "DeleteProduct")]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesDefaultResponseType]
    //public async Task<ActionResult> DeleteProduct([FromRoute] int id, CancellationToken cancellationToken)
    //{
    //    try
    //    {
    //        var deleteProductCommand = new DeleteProductCommand { Id = id };
    //        await _mediator.Send(deleteProductCommand, cancellationToken);
    //        return NoContent();
    //    }
    //    catch (Exception ex)
    //    {
    //        return ResultHandler(ex);
    //    }
    //}
}
