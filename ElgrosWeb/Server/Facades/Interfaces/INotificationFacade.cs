namespace ElgrosWeb.Server.Facades.Interfaces
{
    public interface INotificationFacade
    {
        /// <summary>
        /// This function sends an order confirmation email to provided email with provided content.
        /// </summary>
        /// <param name="content">Email body content</param>
        /// <param name="recipientEmail">Recipients email</param>
        /// <returns></returns>
        Task SendEmail(string content, string recipientEmail);
    }
}
