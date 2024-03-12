using AutoMapper;
using Cloupard.Application.Abstraction.Messaging;
using Cloupard.Domain.Common;
using Cloupard.Domain.Context;
using Cloupard.Domain;

namespace Cloupard.Application.Products.Commands.AddProduct;

internal sealed class AddProductHandler : ICommandHandler<AddProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddProductHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.Model);
        _unitOfWork.ProductRepository.Insert(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}