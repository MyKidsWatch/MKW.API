using MKW.Domain.Dto.DTO.IdentityDTO.Auth;
using MKW.Domain.Entities.ContentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.Base
{
    public class BaseResponseDTO<T> where T : class
    {
        public bool IsSuccess { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<T>? ContentList { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Content { get; private set; }

        public List<string> Errors { get; private set; }

        public BaseResponseDTO(bool isSuccess, T content)
        {
            Errors = new List<string>();
            IsSuccess = isSuccess;
            Content = content;
            ContentList = null;
        }

        public BaseResponseDTO(bool isSuccess, List<T> content)
        {
            Errors = new List<string>();
            IsSuccess = isSuccess;
            Content = null;
            ContentList = content;
        }

        public BaseResponseDTO(bool isSuccess = false)
        {
            Errors = new List<string>();
            IsSuccess = isSuccess;
            Content = null;
            ContentList = null;
        }

        public BaseResponseDTO<T> addErrors(IEnumerable<string> errors) 
        {
            Errors.AddRange(errors);
            return this;
        } 
    }
}
