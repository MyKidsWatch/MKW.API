namespace MKW.Domain.Utility.Exceptions
{
    public class NotFoundException : Exception
    {
        public List<string>? Errors { get; set; }

        public NotFoundException(string message) : base(message)
        {
            Errors ??= new List<string>();

            Errors.Add(message);
        }

        public NotFoundException(IEnumerable<string> messages)
        {
            Errors ??= new List<string>(messages);
        }

        public NotFoundException(params string[] messages)
        {
            Errors ??= new List<string>(messages);
        }
    }
}
