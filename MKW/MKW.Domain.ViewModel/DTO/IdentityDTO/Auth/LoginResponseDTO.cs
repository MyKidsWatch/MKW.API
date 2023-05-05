using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Auth
{
    public class LoginResponseDTO
    {
        public bool IsSuccess { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TokenDTO? Token { get; private set; }

        public List<string> Errors { get; private set; }

        public LoginResponseDTO(bool isSuccess, TokenDTO token)
        {
            Errors = new List<string>();
            IsSuccess = isSuccess;
            Token = token;
        }

        public LoginResponseDTO(bool isSuccess = false)
        {
            Errors = new List<string>();
            IsSuccess = isSuccess;
            Token = null;
        }

        //public LoginResponseDTO(bool isSuccess = true) : this() =>  IsSuccess = isSuccess;
        
        //public LoginResponseDTO(bool isSuccess, TokenDTO token) : this(isSuccess) => Token = token;

        public void addError(string error) => Errors.Add(error);
        public void addErrors(IEnumerable<string> errors) => Errors.AddRange(errors);


    }
}
