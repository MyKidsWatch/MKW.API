using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReportsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IReportService
    {
        Task<BaseResponseDTO<ReportReasonDto>> GetReasons();
    }
}
