using AutoMapper;
using Cloupard.Application.Products.Commands.UpdateProduct;
using Cloupard.Application.Products.Models;
using Cloupard.Application.UnitTests.TestData;
using Cloupard.Domain.Context;
using Cloupard.Domain.Enums;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Cloupard.Application.UnitTests.Product.Commands;

public class UpdateProductCommandTests
{
    private static readonly UpdateProductCommand Command = new(ProductData.UpdateProductModel);
    private static readonly Domain.Product TestProduct = ProductData.TestProduct;

    private readonly UpdateProductHandler _handler;
    private readonly IUnitOfWork _unitOfWorkMock;

    public UpdateProductCommandTests()
    {
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();

        var profile = new UpdateProductModelProfile();
        var configuration = new MapperConfiguration(cfg => 
            cfg.AddProfile(profile));
        var mapper = new Mapper(configuration); 
        _handler = new UpdateProductHandler(_unitOfWorkMock, mapper);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenProductWasNotFound()
    {
        // Arrange
        _unitOfWorkMock.ProductRepository.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        // Act
        var result = await _handler.Handle(Command, CancellationToken.None);
        
        // Assert
        result.IsFailure.Should().Be(true);
        result.Error.ErrorType.Should().Be(ErrorType.NotFound);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenProductWasFound()
    {
        // Arrange
        _unitOfWorkMock.ProductRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(TestProduct);
        
        // Act
        var result = await _handler.Handle(Command, CancellationToken.None);
        
        // Assert
        result.IsSuccess.Should().Be(true);
        _unitOfWorkMock.ProductRepository.Received(1).Update(Arg.Any<Domain.Product>());
    }
}