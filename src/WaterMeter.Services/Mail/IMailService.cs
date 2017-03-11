namespace WaterMeter.Services.Mail
{
    public interface IMailService
    {
        bool Send(MailMessage mailMessage);
    }
}