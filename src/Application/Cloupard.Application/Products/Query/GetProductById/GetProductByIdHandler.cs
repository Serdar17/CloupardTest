using AutoMapper;
using Cloupard.Application.Abstraction.Messaging;
using Cloupard.Application.Products.Models;
using Cloupard.Domain.Common;
using Cloupard.Domain.Context;
using Cloupard.Domain.Models;

namespace Cloupard.Application.Products.Query.GetProductById;

public class GetProductByIdHandler : IQueryHandler<GetProductByIdQuery, ProductModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<ProductModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            return ProductErrors.NotFound(request.ProductId);
        }

        return _mapper.Map<ProductModel>(product);
    }
}