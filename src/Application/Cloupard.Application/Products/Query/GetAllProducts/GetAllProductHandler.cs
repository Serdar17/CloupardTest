using AutoMapper;
using Cloupard.Application.Abstraction.Messaging;
using Cloupard.Application.Products.Models;
using Cloupard.Domain.Common;
using Cloupard.Domain.Context;

namespace Cloupard.Application.Products.Query.GetAllProducts;

internal sealed class GetAllProductHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductModel>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<ProductModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var productQuery = await _unitOfWork.ProductRepository.GetAllAsync(cancellationToken);

        if (!string.IsNullOrWhiteSpace(request.SearchValue))
        {
            productQuery = productQuery.Where(x => x.Name.Contains(request.SearchValue));
        }
        
        var models = _mapper.Map<IEnumerable<ProductModel>>(productQuery);
        return Result<IEnumerable<ProductModel>>.Success(models);
    }
}