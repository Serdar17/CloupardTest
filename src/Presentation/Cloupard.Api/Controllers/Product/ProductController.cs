using Asp.Versioning;
using AutoMapper;
using Cloupard.Api.Controllers.Product.Models;
using Cloupard.Application.Products.Commands.AddProduct;
using Cloupard.Application.Products.Commands.DeleteProduct;
using Cloupard.Application.Products.Commands.UpdateProduct;
using Cloupard.Application.Products.Models;
using Cloupard.Application.Products.Query.GetAllProducts;
using Cloupard.Application.Products.Query.GetProductById;
using Cloupard.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cloupard.Api.Controllers.Product;

/// <summary>
/// Product controller
/// </summary>
/// <response code="400">Bad Request</response>;
/// <response code="401">Unauthorized</response>;
/// <response code="403">Forbidden</response>;
/// <response code="404">Not Found</response>;
/// <response code="409">Conflict</response>;
[Route("api/v{version:apiVersion}/products")]
[Produces("application/json")]
[ApiController]
[ApiVersion("1.0")]
public class ProductController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="mapper"></param>
    public ProductController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    /// <summary>
    /// Get all products
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductModel>), 200)]
    public async Task<IResult> GetAllProductsAsync([FromQuery] string? searchValue)
    {
        var query = new GetAllProductsQuery(searchValue);
        var result = await _sender.Send(query);

        if (result.IsSuccess)
            return Results.Ok(result.Value);

        return result.ToProblemDetails();
    }

    /// <summary>
    /// Get product by id
    /// </summary>
    /// <param name="productId">Unique product id</param>
    [HttpGet("{productId:guid}")]
    public async Task<IResult> GetProductByIdAsync([FromRoute] Guid productId)
    {
        var query = new GetProductByIdQuery(productId);
        var result = await _sender.Send(query);

        if (result.IsSuccess)
            return Results.Ok(result.Value);

        return result.ToProblemDetails();
    }

    /// <summary>
    /// Add product
    /// </summary>
    /// <param name="request">Add product request</param>
    [HttpPost]
    public async Task<IResult> AddProductAsync([FromBody] AddProductRequest request)
    {
        var command = new AddProductCommand(_mapper.Map<AddProductModel>(request));
        var result = await _sender.Send(command);

        if (result.IsSuccess)
            return Results.Ok();

        return result.ToProblemDetails();
    }

    /// <summary>
    /// Update product
    /// </summary>
    /// <param name="request">Update product request</param>
    [HttpPut]
    public async Task<IResult> UpdateProductAsync([FromBody] UpdateProductRequest request)
    {
        var command = new UpdateProductCommand(_mapper.Map<UpdateProductModel>(request));
        var result = await _sender.Send(command);

        if (result.IsSuccess)
            return Results.Ok();

        return result.ToProblemDetails();
    }

    /// <summary>
    /// Delete product by id
    /// </summary>
    /// <param name="productId">Unique product id</param>
    /// <returns></returns>
    [HttpDelete("{productId:guid}")]
    [ProducesResponseType(204)]
    public async Task<IResult> DeleteProductAsync([FromRoute] Guid productId)
    {
        var command = new DeleteProductCommand(productId);
        var result = await _sender.Send(command);

        if (result.IsSuccess)
            return Results.NoContent();

        return result.ToProblemDetails();
    }
}