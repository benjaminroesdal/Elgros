using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Client
{
    public class StateContainer
    {
        private List<BasketItemModel> _basketItems = new List<BasketItemModel>();
        private OrderModel _order = new OrderModel() { User = new UserModel(), PaymentDetails = new PaymentModel()};

        public List<BasketItemModel> BasketItems
        {
            get => _basketItems;
            set
            {
                _basketItems = value;
                NotifyStateChanged();
            }
        }

        public OrderModel Order
        {
            get => _order;
            set
            {
                _order = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void ResetState()
        {
            _basketItems.Clear();
            _order = new OrderModel() { User = new UserModel(), PaymentDetails = new PaymentModel() };
        }
    }
}
