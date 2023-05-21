namespace MKW.Domain.Dto.DTO.EmailDTO
{
    public class EmailOptions
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
    }
}
