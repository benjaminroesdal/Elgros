namespace ElgrosWeb.Server.Facades.Interfaces
{
    public interface INotificationFacade
    {
        Task SendEmail(string content, string recipientEmail);
    }
}
