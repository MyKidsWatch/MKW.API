namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class CheckEmailDTO
    {
        public CheckEmailDTO(bool isUserNameValid)
        {
            IsEmailValid = isUserNameValid;
        }
        public bool IsEmailValid { get; }
    }
}
