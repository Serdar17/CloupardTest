using Cloupard.Application.Abstraction.Messaging;
using Cloupard.Application.Products.Models;

namespace Cloupard.Application.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(UpdateProductModel Model) : ICommand;