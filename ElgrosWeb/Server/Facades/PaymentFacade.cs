using ElgrosWeb.Server.Facades.Interfaces;

namespace ElgrosWeb.Server.Facades
{
    public class PaymentFacade : IPaymentFacade
    {
        public bool CreditCardPayment()
        {
            return true;
        }
    }
}
