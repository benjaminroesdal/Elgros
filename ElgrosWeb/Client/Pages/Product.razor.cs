using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;
using Microsoft.AspNetCore.Components.Routing;
using System.Text.Json;
using System.Web;

namespace ElgrosWeb.Client.Pages
{
    public partial class Product
    {
        List<ProductModel> products = new List<ProductModel>();

        protected override async Task OnInitializedAsync()
        {
            NavManager.LocationChanged += async (sender, e) => await HandleLocationChanged(sender, e);
            stateContainer.OnChange += StateHasChanged;
            await ProcessUrlParameters();
        }
        private async Task HandleLocationChanged(object sender, LocationChangedEventArgs e)
        {
            await ProcessUrlParameters();
            StateHasChanged();
        }

        public void ForceRerender()
        {
            StateHasChanged();
        }


        protected override async Task OnParametersSetAsync()
        {
            await ProcessUrlParameters();
        }

        private async Task ProcessUrlParameters()
        {
            products.Clear();
            var uri = new Uri(NavManager.Uri);
            var queryParameters = HttpUtility.ParseQueryString(uri.Query);

            var encodedSubCategoryData = queryParameters.Get("subCategoryData");
            var decodedSubCategoryData = HttpUtility.UrlDecode(encodedSubCategoryData);

            SubCategoryModel subCategory = null;

            // Check if decodedSubCategoryData contains data before deserializing
            if (!string.IsNullOrWhiteSpace(decodedSubCategoryData))
            {
                try
                {
                    subCategory = JsonSerializer.Deserialize<SubCategoryModel>(decodedSubCategoryData);
                }
                catch (JsonException ex)
                {
                    // Handle deserialization error
                    Console.WriteLine($"Failed to deserialize sub-category data: {ex.Message}");
                }
            }

            var categoryString = queryParameters.Get("category");

            if (subCategory != null)
            {
                // SubCategory
                Console.WriteLine(encodedSubCategoryData);
                products = await ProductService.GetProductsOnSubCategory(subCategory);
                Console.WriteLine(products[0].Name);
            }
            else if (!string.IsNullOrWhiteSpace(categoryString))
            {
                // Category
                var category = Enum.Parse<Category>(categoryString);
                Console.WriteLine(category);
                // Fetch or process products for the category as needed.
            }
            else
            {
                // Neither a valid SubCategory nor Category, handle appropriately.
            }
        }


        public async void AddToBasket(ProductModel product)
        {
            var existingItem = stateContainer.BasketItems.FirstOrDefault(e => e.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
                await localStore.SetItemAsync("localStore_BasketItems", stateContainer.BasketItems);
                return;
            }
            stateContainer.BasketItems.Add(new BasketItemModel() { Product = product, Quantity = 1 });
            await localStore.SetItemAsync("localStore_BasketItems", stateContainer.BasketItems);
            StateHasChanged();
        }
    }
}
