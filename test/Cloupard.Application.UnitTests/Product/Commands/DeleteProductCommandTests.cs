using Cloupard.Application.Products.Commands.DeleteProduct;
using Cloupard.Application.UnitTests.TestData;
using Cloupard.Domain.Context;
using Cloupard.Domain.Enums;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Cloupard.Application.UnitTests.Product.Commands;

public class DeleteProductCommandTests
{
    private static readonly DeleteProductCommand Command = new(ProductData.TestGuid);
    private static readonly Domain.Product TestProduct = ProductData.TestProduct;

    private readonly DeleteProductHandler _handler;
    private readonly IUnitOfWork _unitOfWorkMock;

    public DeleteProductCommandTests()
    {
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();
        _handler = new DeleteProductHandler(_unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenProductDontExists()
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
    public async Task Handle_Should_SuccessResult_WhenProductWasFound()
    {
        // Arrange
        _unitOfWorkMock.ProductRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(TestProduct);
        
        // Act
        var result = await _handler.Handle(Command, CancellationToken.None);
        
        // Assert
        result.IsSuccess.Should().Be(true);
        await _unitOfWorkMock.ProductRepository.Received(1).DeleteAsync(Arg.Any<Guid>());
    }
}