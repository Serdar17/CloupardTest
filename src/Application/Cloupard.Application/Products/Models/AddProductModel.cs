using AutoMapper;
using Cloupard.Domain;

namespace Cloupard.Application.Products.Models;

public class AddProductModel
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public class AddProductModelProfile : Profile
{
    public AddProductModelProfile()
    {
        CreateMap<AddProductModel, Product>();
    }
}