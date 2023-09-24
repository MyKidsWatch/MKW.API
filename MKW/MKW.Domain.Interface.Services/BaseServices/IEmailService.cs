namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface IEmailService
    {
        public void SendConfirmAccountEmail(string[] To, string keycode, string language = "pt-BR");
        public void SendRecoveryPasswordEmail(string[] To, string keycode, string language = "pt-BR");
    }
}
