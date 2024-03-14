namespace Cloupard.MVC.Models;

public class ProductViewModel
{
    public IEnumerable<ProductModel> Products { get; set; }
    public ProductModel ProductModel { get; set; } = new();
    public string? SearchValue { get; set; }
}