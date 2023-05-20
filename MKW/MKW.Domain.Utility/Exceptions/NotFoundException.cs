namespace MKW.Domain.Utility.Exceptions
{
    public class NotFoundException : Exception
    {
        public List<string>? Errors { get; set; }

        public NotFoundException(string message) : base(message)
        {

        }
    }
}
