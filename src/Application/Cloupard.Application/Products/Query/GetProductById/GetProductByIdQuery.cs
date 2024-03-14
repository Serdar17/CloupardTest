using Cloupard.Application.Abstraction.Messaging;
using Cloupard.Application.Products.Models;

namespace Cloupard.Application.Products.Query.GetProductById;

public sealed record GetProductByIdQuery(Guid ProductId) : IQuery<ProductModel>;