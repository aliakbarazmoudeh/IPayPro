using Microsoft.AspNetCore.Mvc;
using TestCleanArchitecture.Application.Common.Models;
using TestCleanArchitecture.Application.Product.Commands.CreateProduct;
using TestCleanArchitecture.Application.Product.Commands.UpdateProductById;
using TestCleanArchitecture.Application.Product.Queries.GetProductById;
using TestCleanArchitecture.Application.Product.Queries.GetProductWithPagination;
using TestCleanArchitecture.Domain.Entities;

namespace TestCleanArchitecture.Web.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("{ProductId}")]
    public async Task<IActionResult> GetProductById([FromRoute] GetProductByIdQuery query)
    {
        PanelProduct? product = await _mediator.Send(query);
        
        if (product is null)
            return NotFound(new { msg = "no Product found with this id" });
        
        return Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult> GetProductsWithPagination([FromQuery] GetProductsWithPaginationQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        Result result = await _mediator.Send(command);
        
        if (result.Succeeded is false)
            return BadRequest(result.Errors);

        return Ok(new { msg = "Product created successfully" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductById([FromBody] UpdateProductByIdCommand command)
    {
        Result result = await _mediator.Send(command);
        if (result.Succeeded is false)
            return BadRequest(result.Errors);
        
        return Ok(new { msg = "Product updated successfully" });
    }
}
