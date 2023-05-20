using MimeKit;

namespace MKW.Domain.Dto.DTO.EmailDTO
{
    public class MessageRecoveryPasswordDTO : BaseMessageEmailDTO
    {
        public MessageRecoveryPasswordDTO(IEnumerable<string> sendToList, string subject, string keycode)
        {
            SendTo = new List<MailboxAddress>();
            SendTo.AddRange(sendToList.Select(sendToItem => new MailboxAddress("", sendToItem)));
            Subject = subject;
            Content = $"" +
                $"<div style=\"margin: 0; padding: 0; font-family: Arial, sans-serif; background-color: #ffffff;\">" +
                    $"<table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">" +
                        $"<tr>" +
                            $"<td bgcolor=\"#ffffff\" align=\"center\" style=\"padding: 40px 0;\">" +
                                $"<h1 style=\"font-size: 40px; font-weight: bold; margin: 0; color: #016FB9;\">" +
                                    $"MyKidsWatch<br>" +
                                    $"Recuperacão de Senha<br> </h1>" +
                            $"</td>" +
                        $"</tr>" +
                        $"<tr>" +
                            $"<td bgcolor=\"#ffffff\" align=\"center\" style=\"padding: 20px 0;\">" +
                                $"<div style=\"max-width: 400px; margin: 0 auto;\">" +
                                    $"<div style=\"background-color: #016FB9; box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.7); padding: 20px;\">" +
                                        $"<h2 style=\"font-size: 24px; font-weight: bold; margin: 0; color: #ffffff;\">Código de Recuperação</h2>" +
                                        $"<p style=\"font-size: 18px; margin: 20px 0; color: #ffffff;\">Utilize o código abaixo para recuperar sua senha:</p>" +
                                        $"<div style=\"font-size: 36px; font-weight: bold; background-color: #ffffff; color: #4CAF50; padding: 10px; text-align: center;\">" +
                                            $"{keycode}" +
                                        $"</div>" +
                                    $"</div>" +
                                $"</div>" +
                            $"</td>" +
                        $"</tr>" +
                    $"</table>" +
                $"</div>";
        }
    }
}
