using Cloupard.Application.Abstraction.Messaging;

namespace Cloupard.Application.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid ProductId) : ICommand;