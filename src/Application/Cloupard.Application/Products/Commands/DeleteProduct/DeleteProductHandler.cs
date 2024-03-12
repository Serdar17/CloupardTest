using Cloupard.Application.Abstraction.Messaging;
using Cloupard.Domain.Common;
using Cloupard.Domain.Context;
using Cloupard.Domain.Models;

namespace Cloupard.Application.Products.Commands.DeleteProduct;

internal sealed class DeleteProductHandler : ICommandHandler<DeleteProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            return ProductErrors.NotFound(request.ProductId);
        }

        await _unitOfWork.ProductRepository.DeleteAsync(product.Id, cancellationToken);
        return Result.Success();
    }
}