using MKW.Domain.Dto.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface IPaymentService
    {
        Task<BaseResponseDTO<string>> CreatePaymentSession();
    }
}
