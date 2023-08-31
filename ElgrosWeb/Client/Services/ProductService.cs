using System.Net.Http.Json;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Client.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Posts model of subcategory to retrieve the products for the selected subcat
    /// </summary>
    /// <param name="model"></param>
    /// <returns>products</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<List<ProductModel>> GetProductsOnSubCategory(SubCategoryModel model)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/Product/GetProductsOnSubCategory", model);
    
        //Check statuscode of response and returns products
        if (response.IsSuccessStatusCode)
        {
            var products = await response.Content.ReadFromJsonAsync<List<ProductModel>>();
            return products;
        }
        else
        {
            // Handle the error or throw an exception
            throw new HttpRequestException($"Response code: {response.StatusCode}, Error: {await response.Content.ReadAsStringAsync()}");
        }
    }

    public async Task<List<ProductModel>> GetVvsProducts()
    {
        try
        {
            var products = await _httpClient.GetFromJsonAsync<List<ProductModel>>("/api/Product/GetVvsProducts");
            return products;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<List<ProductModel>> GetElectricalProducts()
    {
        try
        {
            var products = await _httpClient.GetFromJsonAsync<List<ProductModel>>("/api/Product/GetElectricalProducts");
            return products;
        }
        catch (Exception ex)
        {
            throw; 
        }
    }

}