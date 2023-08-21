using System.Net;
using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;
using ElgrosWeb.Client.Services;

namespace ElgrosWeb.Client.Shared;

public partial class MainLayout
{
    
    bool _drawerOpen = false;
    List<SubCategoryModel> SubCategories;
    
    protected override async Task OnInitializedAsync()
    {
        SubCategories = await CategoryService.FetchSubCategories();
    }
    
    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }
}