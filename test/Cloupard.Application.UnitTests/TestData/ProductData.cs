using Cloupard.Application.Products.Models;

namespace Cloupard.Application.UnitTests.TestData;

public static class ProductData
{
    public static Guid TestGuid = Guid.Parse("0aa8570f-b496-4138-90f1-585c3522ebf2");
    public static AddProductModel ProductModel = new() { Name = "TestName", Description = "TestDescription" };

    public static UpdateProductModel UpdateProductModel =
        new() { Id = TestGuid, Name = "UpdateName", Description = "UpdateDescription" };

    public static Domain.Product TestProduct = new() { Id = TestGuid, Name = "TestName", Description = "TestDescription" };
    public static ProductModel TestProductModel = new() { Id = TestGuid, Name = "TestName", Description = "TestDescription" };

    public static IList<Domain.Product> TestProducts => Enumerable.Range(1, 5).Select(x => TestProduct).ToList();
    public static IList<ProductModel> TestProductModels => Enumerable.Range(1, 5).Select(x => TestProductModel).ToList();
}