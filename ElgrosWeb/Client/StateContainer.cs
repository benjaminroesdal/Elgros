using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Client
{
    public class StateContainer
    {
        private List<BasketItemModel> _basketItems = new List<BasketItemModel>();

        public List<BasketItemModel> BasketItems
        {
            get => _basketItems;
            set
            {
                _basketItems = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
