namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class CheckUserNameDTO
    {
        public CheckUserNameDTO(bool isUserNameValid)
        {
            IsUserNameValid = isUserNameValid;
        }
        public bool IsUserNameValid { get; }

    }
}
