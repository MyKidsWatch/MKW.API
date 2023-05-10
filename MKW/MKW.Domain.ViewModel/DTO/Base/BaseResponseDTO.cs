using MKW.Domain.Dto.DTO.IdentityDTO.Auth;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Interface.Repository.Base;
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
        public bool IsSuccess { get; private set; } = true;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<T>? ContentList { get; private set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Content { get; private set; } = null;

        public List<string> Errors { get; private set; } = null;

        public BaseResponseDTO<T> WithSuccess(T content, bool isSuccess = true)
        {
            IsSuccess = isSuccess;
            Content = content;
            return this;
        }

        public BaseResponseDTO<T> WithSuccesses(IEnumerable<T> content, bool isSuccess = true)
        {
            IsSuccess = isSuccess;
            ContentList = content;
            return this;
        }

        public BaseResponseDTO<T> WithErrors(IEnumerable<string> errors, bool isSuccess = false) 
        {
            Errors = new List<string>();
            IsSuccess = isSuccess;
            Errors.AddRange(errors);
            return this;
        }
    }
}
