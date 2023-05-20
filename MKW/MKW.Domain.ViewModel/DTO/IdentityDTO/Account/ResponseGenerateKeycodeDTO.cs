namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class ResponseGenerateKeycodeDTO
    {
        public ResponseGenerateKeycodeDTO(bool isKeycodeSent)
        {
            IsKeycodeSent = isKeycodeSent;
        }
        public bool IsKeycodeSent { get; }
    }
}
