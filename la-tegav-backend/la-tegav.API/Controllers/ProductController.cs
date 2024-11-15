using la_tegav.API.Custom;
using la_tegav.Application.Dtos;
using la_tegav.Application.UseCases.ProductEntity.Commands.CreateProduct;
using la_tegav.Application.UseCases.ProductEntity.Commands.DeleteProduct;
using la_tegav.Application.UseCases.ProductEntity.Commands.UpdateProduct;
using la_tegav.Application.UseCases.ProductEntity.Queries.GetAllProducts;
using la_tegav.Application.UseCases.ProductEntity.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace la_tegav.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : CustomReturnController
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateProduct", Name = "CreateProduct")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductDto>> Create
    ([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpGet("GetAllProducts", Name = "GetAllProducts")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<ProductDto>> GetAllProducts(CancellationToken cancellationToken)
    {
        try
        {
            var response = await _mediator.Send(new GetAllProductsQuery(), cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpGet("GetProductById", Name = "GetProductById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ProductDto>> GetProductById(int Id, CancellationToken cancellationToken)
    {
        try
        {
            var productCommand = new GetProductByIdQuery { Id = Id };
            var response = await _mediator.Send(productCommand, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpPut("UpdateProduct", Name = "UpdateProduct")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand, CancellationToken cancellationToken)
    {
        try
        {
            await _mediator.Send(updateProductCommand, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }

    [HttpDelete("DeleteProduct/{id}", Name = "DeleteProduct")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteProduct([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            var deleteProductCommand = new DeleteProductCommand { Id = id };
            await _mediator.Send(deleteProductCommand, cancellationToken);
            return NoContent();
        }
        catch (Exception ex)
        {
            return ResultHandler(ex);
        }
    }
}
