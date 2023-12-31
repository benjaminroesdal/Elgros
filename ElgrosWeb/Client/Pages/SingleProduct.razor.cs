﻿using ElgrosWeb.Shared.Models;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Web;

namespace ElgrosWeb.Client.Pages
{
    public partial class SingleProduct
    {
        ProductModel? product;

        protected override async Task OnInitializedAsync()
        {
            await ProcessUrlParameters();
        }

        //Method reads the url to retreive the prev selected product
        private async Task ProcessUrlParameters()
        {
            var uri = new Uri(NavManager.Uri);
            var queryParameters = HttpUtility.ParseQueryString(uri.Query);
            var encodedProduct = queryParameters.Get("product");
            var decodedProduct = HttpUtility.UrlDecode(encodedProduct);
            product = JsonSerializer.Deserialize<ProductModel>(decodedProduct);
        }


        /// <summary>
        /// Adds to basket and saves in localstorage and updates state
        /// </summary>
        /// <param name="product"></param>
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
