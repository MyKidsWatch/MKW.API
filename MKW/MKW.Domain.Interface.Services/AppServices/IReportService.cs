using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReportsDTO;

namespace MKW.Domain.Interface.Services.AppServices
{
    public interface IReportService
    {
        Task<BaseResponseDTO<ReportReasonDto>> GetReasons(string language = "pt-BR");
        Task<BaseResponseDTO<ReportReasonDto>> GetReasonById(int id, string language = "pt-BR");
        Task<BaseResponseDTO<ReportDto>> GetReports(int page = 1, int pageSize = 10, int? reasonId = null, int? statusId = null, string orderBy = "CreateDate", bool orderByAscending = true, string language = "pt-BR");
        Task<BaseResponseDTO<ReportDto>> AddReport(CreateReportDto model);
        Task<BaseResponseDTO<ReportDto>> UpdateReportStatus(UpdateReportStatusDto model);
        Task<BaseResponseDTO<ReportDto>> RespondReport(ReportResponseDto model);
        Task<BaseResponseDTO<ReportStatusDto>> GetStatus(string language = "pt-BR");
    }
}
