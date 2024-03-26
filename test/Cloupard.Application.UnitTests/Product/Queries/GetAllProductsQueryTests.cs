using AutoMapper;
using Cloupard.Application.Products.Models;
using Cloupard.Application.Products.Query.GetAllProducts;
using Cloupard.Application.UnitTests.TestData;
using Cloupard.Domain.Context;
using FluentAssertions;
using NSubstitute;

namespace Cloupard.Application.UnitTests.Product.Queries;

public class GetAllProductsQueryTests
{
    private readonly GetAllProductHandler _handler;
    private readonly IUnitOfWork _unitOfWorkMock;

    public GetAllProductsQueryTests()
    {
        _unitOfWorkMock = Substitute.For<IUnitOfWork>();
        var profile = new ProductModelProfile();
        var configuration = new MapperConfiguration(cfg => 
            cfg.AddProfile(profile));
        var mapper = new Mapper(configuration);
        _handler = new GetAllProductHandler(_unitOfWorkMock, mapper);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenSearchValueEmpty()
    {
        // Arrange
        var productsQuery = ProductData.TestProducts.AsQueryable();
        _unitOfWorkMock.ProductRepository.GetAllAsync().Returns(productsQuery);
        
        // Act
        var result = await _handler.Handle(new GetAllProductsQuery(SearchValue: string.Empty), CancellationToken.None);
        
        // Assert
        result.IsSuccess.Should().Be(true);
        result.Value.Count().Should().Be(5);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenSearchValueNotEmpty()
    {
        // Arrange
        var productsQuery = ProductData.TestProducts.AsQueryable();
        _unitOfWorkMock.ProductRepository.GetAllAsync().Returns(productsQuery);
        
        // Act
        var result = await _handler.Handle(new GetAllProductsQuery(SearchValue: "Test"), CancellationToken.None);
        
        // Assert
        result.IsSuccess.Should().Be(true);
        result.Value.Count().Should().BeGreaterThanOrEqualTo(0);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnEmptyResult_WhenSearchValueNotEmpty()
    {
        // Arrange
        var productsQuery = ProductData.TestProducts.AsQueryable();
        _unitOfWorkMock.ProductRepository.GetAllAsync().Returns(productsQuery);
        
        // Act
        var result = await _handler.Handle(new GetAllProductsQuery(SearchValue: "11Test"), CancellationToken.None);
        
        // Assert
        result.IsSuccess.Should().Be(true);
        result.Value.Count().Should().Be(0);
    }
}