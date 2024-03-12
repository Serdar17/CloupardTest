using AutoMapper;
using Cloupard.Domain;

namespace Cloupard.Application.Products.Models;

public class UpdateProductModel
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}

public class UpdateProductModelProfile : Profile
{
    public UpdateProductModelProfile()
    {
        CreateMap<UpdateProductModel, Product>()
            .ForMember(x => x.Id, opt => opt.Ignore());
    }
}