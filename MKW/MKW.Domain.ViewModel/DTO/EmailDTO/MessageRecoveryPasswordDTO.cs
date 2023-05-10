using MimeKit;
using MKW.Domain.Entities.ContentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MKW.Domain.Dto.DTO.EmailDTO
{
    public class MessageRecoveryPasswordDTO : BaseMessageEmailDTO
    {
        public MessageRecoveryPasswordDTO(IEnumerable<string> sendToList, string subject, string token, int userId)
        {
            SendTo = new List<MailboxAddress>();
            SendTo.AddRange(sendToList.Select(sendToItem => new MailboxAddress("", sendToItem)));
            Subject = subject;
            //TODO: mudar para dominio MKW
            Content = $"<div style=\"margin: 0; padding: 0; font-family: Arial, sans-serif;\">" +
                    $" <table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">" +
                        $"<tr>" +
                        $"<td bgcolor=\"#ffffff\" align=\"center\">" +
                            $"<table cellpadding=\"0\" cellspacing=\"0\" width=\"600\" style=\"max-width: 600px;\">" +
                                $"<tr>" +
                                    $"<td align=\"center\" style=\"padding: 40px 0;\">" +
                                        $"<h1 style=\"font-size: 32px; font-weight: bold; margin: 0;\">MyKidsWatch</h1>" +
                                    $"</td>" +
                                    $"</tr>" +
                                        $"<tr>" +
                                         $"<td align=\"center\" style=\"padding: 20px 0;\">" +
                                            $"<h2 style=\"font-size: 24px; font-weight: bold; margin: 0;\">Recuperar Senha</h2>" +
                                        $"</td>" +
                                        $"</tr>" +
                                        $"<tr>" +
                                        $"<td align=\"center\" style=\"padding: 20px 0;\">" +
                                        $"<a href=\"https://localhost:7240/v1/account/confirmEmail?UserId={userId}&ActivationToken={token}\" target=\"_blank\" style=\"display: inline-block; padding: 15px 30px; background-color: #4CAF50; color: #ffffff; font-size: 18px; font-weight: bold; text-decoration: none; border-radius: 5px;\">" +
                                        $"Recuperar Senha</a>" +
                                    $"</td><" +
                                $"/tr>" +
                            $"</table>" +
                        $"</td>" +
                        $"</tr>" +
                    $"</table>" +
                $"</div>";
        }
    }
}
