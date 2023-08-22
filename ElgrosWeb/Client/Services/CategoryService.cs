using System.Net;
using ElgrosWeb.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;
using ElgrosWeb.Shared.Enums;


namespace ElgrosWeb.Client.Services;

public class CategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<SubCategoryModel>> FetchSubCategories(Category category)
    {
        try
        {
            var response =
                await _httpClient.GetFromJsonAsync<List<SubCategoryModel>>($"/api/Product/GetAllSubcategorys?category=VVS");
            return response ?? new List<SubCategoryModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching subcategories: {ex.Message}");
        }
        return new List<SubCategoryModel>();
    }
}