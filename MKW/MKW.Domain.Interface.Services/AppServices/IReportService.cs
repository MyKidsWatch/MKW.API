using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReportsDTO;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IReportService
    {
        Task<BaseResponseDTO<ReportReasonDto>> GetReasons();
        Task<BaseResponseDTO<ReportReasonDto>> GetReasonById(int id);
        Task<BaseResponseDTO<ReportDto>> GetReports();
    }
}
