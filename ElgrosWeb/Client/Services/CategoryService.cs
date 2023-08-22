using System.Net;
using ElgrosWeb.Shared.Models;
using System.Net.Http.Json;


namespace ElgrosWeb.Client.Services;

public class CategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<SubCategoryModel>> FetchSubCategories()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<SubCategoryModel>>("/GetAllSubcategorys");
            if (response != null)
            {
                return response;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching subcategories: {ex.Message}");
        }
        return null;
    }
}