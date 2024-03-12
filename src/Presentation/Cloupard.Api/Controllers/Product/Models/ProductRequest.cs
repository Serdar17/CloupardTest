using AutoMapper;
using Cloupard.Application.Products.Models;
using FluentValidation;

namespace Cloupard.Api.Controllers.Product.Models;

/// <summary>
/// Add product request
/// </summary>
public class AddProductRequest
{
    /// <summary>
    /// Product name
    /// </summary>
    /// <example>Andrey</example>
    public required string Name { get; set; }

    /// <summary>
    /// Product description (optional)
    /// </summary>
    public string? Description { get; set; }
}

/// <summary>
/// Validation rules for <see cref="AddProductRequest"/>
/// </summary>
public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
{
    /// <summary>
    /// Ctor for <see cref="AddProductRequestValidator"/>
    /// </summary>
    public AddProductRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(255);
    }
}

/// <summary>
/// Mapping rules for <see cref="AddProductRequest"/>
/// </summary>
public class AddProductRequestProfile : Profile
{
    /// <summary>
    /// Ctor for <see cref="AddProductRequestProfile"/>
    /// </summary>
    public AddProductRequestProfile()
    {
        CreateMap<AddProductRequest, AddProductModel>();
    }
}