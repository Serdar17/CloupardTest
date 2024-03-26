using AutoMapper;
using Cloupard.Application.Products.Commands.AddProduct;
using Cloupard.Application.Products.Models;
using Cloupard.Application.UnitTests.TestData;
using Cloupard.Domain.Context;
using FluentAssertions;
using NSubstitute;

namespace Cloupard.Application.UnitTests.Product.Commands;

public class AddProductCommandTests
{
    private static readonly AddProductCommand Command = new(ProductData.ProductModel);
    private static readonly Domain.Product TestProduct = ProductData.TestProduct; 

    private readonly AddProductHandler _handler;
    private readonly IUnitOfWork _unitOfWorkMock;

    public AddProductCommandTests()
    {
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();
        
        var myProfile = new AddProductModelProfile();
        var configuration = new MapperConfiguration(cfg => 
            cfg.AddProfile(myProfile));
        var mapper = new Mapper(configuration);
        _handler = new AddProductHandler(_unitOfWorkMock, mapper);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenProductCreated()
    {
        // Arrange

        // Act
        var result = await _handler.Handle(Command, CancellationToken.None);
        
        // Assert
        result.IsSuccess.Should().Be(true);
        _unitOfWorkMock.ProductRepository.Received(1).Insert(Arg.Any<Domain.Product>());
        await _unitOfWorkMock.Received(1).SaveChangesAsync();
    }
}