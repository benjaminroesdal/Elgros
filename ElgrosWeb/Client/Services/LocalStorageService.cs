using Blazored.LocalStorage;
using ElgrosWeb.Shared.Models;
using System.Reflection.Metadata;

namespace ElgrosWeb.Client.Services
{
    public class LocalStorageService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly StateContainer _stateContainer;

        public LocalStorageService(ILocalStorageService localStorage, StateContainer stateContainer)
        {
            _localStorageService = localStorage;
            _stateContainer = stateContainer;
        }

        public async Task AddToBasket(ProductModel product)
        {
            var existingItem = _stateContainer.BasketItems.FirstOrDefault(e => e.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
                await _localStorageService.SetItemAsync("localStore_BasketItems", _stateContainer.BasketItems);
                return;
            }
            _stateContainer.BasketItems.Add(new BasketItemModel() { Product = product, Quantity = 1 });
            await _localStorageService.SetItemAsync("localStore_BasketItems", _stateContainer.BasketItems);
        }

        public async Task RemoveFromBasket(int itemId)
        {
            var currentItems = await _localStorageService.GetItemAsync<List<BasketItemModel>>("localStore_BasketItems");
            var item = currentItems.FirstOrDefault(e => e.Product.Id == itemId);
            item.Quantity--;
            await _localStorageService.SetItemAsync("localStore_BasketItems", currentItems);
            _stateContainer.BasketItems = currentItems;
        }

        public async Task ClearItemFromBasket(int itemId)
        {
            var currentItems = await _localStorageService.GetItemAsync<List<BasketItemModel>>("localStore_BasketItems");
            currentItems.RemoveAll(e => e.Product.Id == itemId);
            await _localStorageService.SetItemAsync("localStore_BasketItems", currentItems);
            _stateContainer.BasketItems = currentItems;
        }

        public async Task ClearBasket()
        {
            await _localStorageService.ClearAsync();
        }

        public async Task<List<BasketItemModel>> TryGetLocalStorage()
        {
            List<BasketItemModel> items = new List<BasketItemModel>();
            try
            {
                items = await _localStorageService.GetItemAsync<List<BasketItemModel>>("localStore_BasketItems");
            }
            catch (Exception) { }
            return items;
        }
    }
}
