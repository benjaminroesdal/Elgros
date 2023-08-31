namespace ElgrosWeb.Server.Facades.Interfaces
{
    public interface IPaymentFacade
    {
        /// <summary>
        /// Verify credit card payment
        /// </summary>
        /// <returns>boolean based on state of payment</returns>
        bool CreditCardPayment();
    }
}
