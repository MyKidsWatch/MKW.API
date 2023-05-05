namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface IEmailService
    {
        public void sendEmail(string[] To, string subject, int userId, string token);
    }
}
