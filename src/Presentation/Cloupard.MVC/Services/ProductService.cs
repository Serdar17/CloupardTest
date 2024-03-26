using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Cloupard.MVC.Models;
using Cloupard.Services.Logger.Logger;
using Cloupard.Services.Settings.Settings;
using Microsoft.AspNetCore.Mvc;

namespace Cloupard.MVC.Services;

public class ProductService : IProductService
{
    private HttpClient _client;
    private readonly string _root;
    private readonly IAppLogger _logger;

    public ProductService(HttpClient client,
        WebSettings settings, IAppLogger logger)
    {
        _client = client;
        _logger = logger;
        _root = $"{settings.Url}/api/v1/products";
    }

    public async Task<ProductModel?> GetProductByIdAsync(Guid productId)
    {
        var response = await _client.GetAsync($"{_root}/{productId}");
        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            return JsonSerializer.Deserialize<ProductModel>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        return null;
    }

    public async Task<IEnumerable<ProductModel>> GetAllProductsAsync(string? searchValue)
    {
        var response = await _client.GetAsync($"{_root}?searchValue={searchValue}");
        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            return JsonSerializer.Deserialize<IEnumerable<ProductModel>>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<ProductModel>();
        }

        return Enumerable.Empty<ProductModel>();
    }

    public async Task CreateProductAsync(ProductModel model)
    {
        var json = JsonSerializer.Serialize(model);
        var data = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _client.PostAsync(_root, data);
    }

    public async Task UpdateProductAsync(ProductModel model)
    {
        var json = JsonSerializer.Serialize(model);
        var data = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await _client.PutAsync(_root, data);
    }

    public async Task DeleteProductAsync(Guid productId)
    {
        var response = await _client.DeleteAsync($"{_root}/{productId}");
        if (response.IsSuccessStatusCode)
        {
            _logger.Warning("Request ended");
        }
    }
}