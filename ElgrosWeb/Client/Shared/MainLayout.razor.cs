using System.Net;
using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;
using ElgrosWeb.Client.Services;

namespace ElgrosWeb.Client.Shared;

public partial class MainLayout
{
    
    bool _drawerOpen = false;
    List<SubCategoryModel> SubCategories = new List<SubCategoryModel>();
    
    protected override async Task OnInitializedAsync()
    {
        SubCategories = await CategoryService.FetchSubCategories(Category.VVS);
        var products = await ProductService.GetProductsOnSubCategory(SubCategories[0]);

        Console.WriteLine(SubCategories);
        Console.WriteLine(products);
    }
    
    private Task HandleItemClick(SubCategoryModel subCategory)
    {
        throw new NotImplementedException();
    }
    
    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }
}