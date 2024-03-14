using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cloupard.MVC.Models;
using Cloupard.MVC.Services;

namespace Cloupard.MVC.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(
        ILogger<ProductController> logger,
        IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? searchValue)
    {
        var models = await _productService.GetAllProductsAsync(searchValue);
        var viewModels = new ProductViewModel { Products = models };
        return View(viewModels);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        return Json(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductViewModel model)
    {
        await _productService.CreateProductAsync(model.ProductModel);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Update(ProductViewModel model)
    {
        await _productService.UpdateProductAsync(model.ProductModel);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(ProductViewModel model)
    {
        await _productService.DeleteProductAsync(model.ProductModel.Id);
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}