using Cloupard.Application.Abstraction.Messaging;
using Cloupard.Application.Products.Models;

namespace Cloupard.Application.Products.Query.GetAllProducts;

public sealed record GetAllProductsQuery(string? SearchValue) : IQuery<IEnumerable<ProductModel>>;