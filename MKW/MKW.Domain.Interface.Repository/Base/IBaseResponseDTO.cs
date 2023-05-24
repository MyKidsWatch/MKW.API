namespace MKW.Domain.Interface.Repository.Base
{
    public interface IBaseResponseDTO
    {
        Task<object> WithSuccess(object content, bool isSuccess = true);
        Task<object> WithSuccesses(IEnumerable<object> content, bool isSuccess = true);
        Task<object> WithErrors(IEnumerable<string> errors, bool isSuccess = false);
    }
}
