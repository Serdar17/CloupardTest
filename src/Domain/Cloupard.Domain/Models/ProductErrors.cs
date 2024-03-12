using Cloupard.Domain.Common;

namespace Cloupard.Domain.Models;

public static class ProductErrors
{
    public static Error NotFound(Guid productId) =>
        Error.NotFound("Products.NotFound", $"Product with id={productId} was not found");
}