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


        /// <summary>
        /// Extracts and decodes URL query parameters from the
        /// current navigation URI and attempts to decode.
        /// </summary>
        /// <returns></returns>
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
                products = await ProductService.GetProductsOnSubCategory(subCategory);
            }
            else if (!string.IsNullOrWhiteSpace(categoryString))
            {
                // Category
                var category = Enum.Parse<Category>(categoryString);
            }
            else
            {
                // Neither a valid SubCategory nor Category, handle appropriately.
            }
        }


        public async void AddToBasket(ProductModel product)
        {
            await localStorageService.AddToBasket(product);
            StateHasChanged();
        }

        public void SelectProduct(ProductModel product)
        {
            if (true)
            {
                var subCategoryJson = JsonSerializer.Serialize(product);
                var encodedSubCategory = HttpUtility.UrlEncode(subCategoryJson);
                NavManager.NavigateTo($"/SingleProduct?product={encodedSubCategory}");
            }
        }
    }
}
