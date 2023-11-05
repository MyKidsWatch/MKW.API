using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReportsDTO;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IReportService
    {
        Task<BaseResponseDTO<ReportReasonDto>> GetReasons();
        Task<BaseResponseDTO<ReportReasonDto>> GetReasonById(int id);
        Task<BaseResponseDTO<ReportDto>> GetReports(int page = 1, int pageSize = 10, int? reasonId = null);
        Task<BaseResponseDTO<ReportDto>> AddReport(CreateReportDto model);
        Task<BaseResponseDTO<ReportDto>> UpdateReportStatus(UpdateReportStatusDto model);
    }
}
