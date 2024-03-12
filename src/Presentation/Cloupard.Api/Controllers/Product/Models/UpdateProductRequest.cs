using AutoMapper;
using Cloupard.Application.Products.Models;
using FluentValidation;

namespace Cloupard.Api.Controllers.Product.Models;

/// <summary>
/// Update product request
/// </summary>
public class UpdateProductRequest
{
    /// <summary>
    /// Product id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Product name
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Product description (optional)
    /// </summary>
    public string? Description { get; set; }
}

/// <summary>
/// Mapping rules for <see cref="UpdateProductRequest"/>
/// </summary>
public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    /// <summary>
    /// ctor for <see cref="UpdateProductRequestValidator"/>
    /// </summary>
    public UpdateProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(255);
    }
}

/// <summary>
/// Mapping rules for <see cref="UpdateProductRequest"/>
/// </summary>
public class UpdateProductRequestProfile : Profile
{
    /// <summary>
    /// Ctor for <see cref="UpdateProductRequestProfile"/>
    /// </summary>
    public UpdateProductRequestProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductModel>();
    }
}