using MKW.Domain.Dto.DTO.EmailDTO;

namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface IEmailService
    {
        public void sendConfirmAccountEmail(string[] To, string subject, string keycode);
        public void sendRecoveryPasswordEmail(string[] To, string subject, string keycode);
    }
}
