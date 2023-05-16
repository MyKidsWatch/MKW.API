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
        public List<T>? Content { get; private set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; private set; } = null;

        public BaseResponseDTO() { }
        public BaseResponseDTO(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public BaseResponseDTO<T> WithSuccesses(IEnumerable<T> content, bool isSuccess = true)
        {
            if (Content is null) Content = new List<T>();
            Content.AddRange(content);
            IsSuccess = isSuccess;
            return this;
        }
        public BaseResponseDTO<T> WithErrors(IEnumerable<string> errors, bool isSuccess = false) 
        {
            if (Errors is null) Errors = new List<string>();
            Errors.AddRange(errors);
            IsSuccess = isSuccess;
            return this;
        }

        public BaseResponseDTO<T> AddContent(T content, bool isSuccess = true)
        {
            if (Content is null) Content = new List<T>();
            Content.Add(content);
            IsSuccess = isSuccess;
            return this;
        }

        public BaseResponseDTO<T> AddError(string error, bool isSuccess = false)
        {
            if(Errors is null) Errors = new List<string>();
            Errors.Add(error);
            IsSuccess = isSuccess;
            return this;
        }
    }
}
