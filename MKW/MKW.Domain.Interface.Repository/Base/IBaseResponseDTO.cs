using MKW.Domain.Entities.ContentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Repository.Base
{
    public interface IBaseResponseDTO
    {
        Task<object> WithSuccess(object content, bool isSuccess = true);
        Task<object> WithSuccesses(IEnumerable<object> content, bool isSuccess = true);
        Task<object> WithErrors(IEnumerable<string> errors, bool isSuccess = false);
    }
}
