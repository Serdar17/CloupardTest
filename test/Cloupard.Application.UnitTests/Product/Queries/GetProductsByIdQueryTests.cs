using AutoMapper;
using Cloupard.Application.Products.Models;
using Cloupard.Application.Products.Query.GetProductById;
using Cloupard.Application.UnitTests.TestData;
using Cloupard.Domain.Context;
using Cloupard.Domain.Enums;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Cloupard.Application.UnitTests.Product.Queries;

public class GetProductsByIdQueryTests
{
    private static readonly GetProductByIdQuery Query = new(ProductData.TestGuid);
    private static readonly Domain.Product TestProduct = ProductData.TestProduct;

    private readonly GetProductByIdHandler _handler;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsByIdQueryTests()
    {
        _unitOfWork = Substitute.For<IUnitOfWork>();

        var profile = new ProductModelProfile();
        var configuration = new MapperConfiguration(cfg => 
            cfg.AddProfile(profile));
        var mapper = new Mapper(configuration);
        _handler = new GetProductByIdHandler(_unitOfWork, mapper);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenProductWasNotFound()
    {
        // Arrange
        _unitOfWork.ProductRepository.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        // Act
        var result = await _handler.Handle(Query, CancellationToken.None);
        
        // Assert
        result.IsFailure.Should().Be(true);
        result.Error.ErrorType.Should().Be(ErrorType.NotFound);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenProductWasFound()
    {
        // Arrange
        _unitOfWork.ProductRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(TestProduct);

        // Act
        var result = await _handler.Handle(Query, CancellationToken.None);
        
        // Assert
        result.IsSuccess.Should().Be(true);
        result.Value.Id.Should().Be(TestProduct.Id);
        result.Value.Name.Should().Be(TestProduct.Name);
    }
}