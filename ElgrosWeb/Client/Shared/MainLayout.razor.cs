using System.Net;
using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;
using ElgrosWeb.Client.Services;
using System.Text.Json;
using System.Web;

namespace ElgrosWeb.Client.Shared;

public partial class MainLayout
{
    
    bool _drawerOpen = false;
    List<SubCategoryModel> SubCategories = new List<SubCategoryModel>();
    
    protected override async Task OnInitializedAsync()
    {
        foreach (Category category in Enum.GetValues(typeof(Category)))
        {
            var SubCategory = await CategoryService.FetchSubCategories(category);
            SubCategories.AddRange(SubCategory);
        }
    }

    // Method to handle SubCategoryModel
    private void HandleItemClick(SubCategoryModel subCategory)
    {
        if (subCategory != null)
        {
            var subCategoryJson = JsonSerializer.Serialize(subCategory);
            var encodedSubCategory = HttpUtility.UrlEncode(subCategoryJson);
            NavManager.NavigateTo($"/Product?subCategoryData={encodedSubCategory}");
        }
        else
        {
            throw new NotImplementedException("SubCategory handling is not implemented.");
        }
    }


    // Method to handle Category
    private void HandleItemClick(Category category)
    {
        if (category != default(Category))
        {
            NavManager.NavigateTo($"/TargetPageForCategory?category={category}");
        }
        else
        {
            throw new NotImplementedException("Category handling is not implemented.");
        }
    }

    private void HandleBasketClick()
    {
        NavManager.NavigateTo("/Basket");
    }

    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }
}