namespace MKW.Domain.Utility.Exceptions
{
    public class BadRequestException : Exception
    {
        public List<string>? Errors { get; set; }

        public BadRequestException(string message) : base(message)
        {
            Errors ??= new List<string>();

            Errors.Add(message);
        }

        public BadRequestException(IEnumerable<string> messages)
        {
            Errors ??= new List<string>(messages);
        }

        public BadRequestException(params string[] messages)
        {
            Errors ??= new List<string>(messages);
        }
    }
}
