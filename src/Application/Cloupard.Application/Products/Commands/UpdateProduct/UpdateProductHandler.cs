using AutoMapper;
using Cloupard.Application.Abstraction.Messaging;
using Cloupard.Domain.Common;
using Cloupard.Domain.Context;
using Cloupard.Domain.Models;

namespace Cloupard.Application.Products.Commands.UpdateProduct;

internal sealed class UpdateProductHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Model.Id, cancellationToken);

        if (product is null)
        {
            return ProductErrors.NotFound(request.Model.Id);
        }

        _mapper.Map(request.Model, product);
        _unitOfWork.ProductRepository.Update(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}