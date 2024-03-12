using Cloupard.Application.Abstraction.Messaging;
using Cloupard.Application.Products.Models;

namespace Cloupard.Application.Products.Commands.AddProduct;

public sealed record AddProductCommand(AddProductModel Model) : ICommand;