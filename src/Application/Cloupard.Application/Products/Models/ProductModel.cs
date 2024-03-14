using AutoMapper;
using Cloupard.Domain;

namespace Cloupard.Application.Products.Models;

public class ProductModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public class ProductModelProfile : Profile
{
    public ProductModelProfile()
    {
        CreateMap<Product, ProductModel>();
    }
}