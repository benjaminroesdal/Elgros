﻿using System.Net.Http.Json;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Client.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductModel>> GetProductsOnSubCategory(SubCategoryModel model)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/Product/GetProductsOnSubCategory", model);
    
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
        var products = await _httpClient.GetFromJsonAsync<List<ProductModel>>("/api/Product/GetVvsProducts");
        return products;       
    }
    public async Task<List<ProductModel>> GetElectricalProducts()
    {
        var products = await _httpClient.GetFromJsonAsync<List<ProductModel>>("/api/Product/GetElectricalProducts");
        return products;
    }
}