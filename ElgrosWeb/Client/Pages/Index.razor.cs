using ElgrosWeb.Shared.Models;
using MudBlazor;

namespace ElgrosWeb.Client.Pages
{
    public partial class Index
    {
        private MudCarousel<ProductModel> _carousel;
        private bool _arrows = true;
        private bool _bullets = true;
        private bool _enableSwipeGesture = true;
        private bool _autocycle = true;
        private int selectedIndex = 2;
        private int selectedIndex2 = 2;
        List<ProductModel> VVSProducts = new List<ProductModel>();
        List<ProductModel> ElecticalProducts = new List<ProductModel>();

        protected override async Task OnInitializedAsync()
        {
            GetProductsForDisplay();
        }

        private async Task GetProductsForDisplay()
        {
            VVSProducts = await ProductService.GetVvsProducts();
            ElecticalProducts = await ProductService.GetElectricalProducts();
        }
    }
}
