using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReportsDTO;
using MKW.Domain.Interface.Repository.ReportAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;

namespace MKW.Services.AppServices
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IReportReasonRepository _reportReasonRepository;

        public ReportService(IReportRepository reportRepository, IReportReasonRepository reportReasonRepository)
        {
            _reportRepository = reportRepository;
            _reportReasonRepository = reportReasonRepository;
        }

        public async Task<BaseResponseDTO<ReportReasonDto>> GetReasons()
        {
            var reasons = await _reportReasonRepository.GetActive() ?? throw new NotFoundException("Report Reasons not found.");

            return new BaseResponseDTO<ReportReasonDto>().AddContent(reasons.Select(x => new ReportReasonDto(x)));
        }

        public async Task<BaseResponseDTO<ReportReasonDto>> GetReasonById(int id)
        {
            var reason = await _reportReasonRepository.GetById(id) ?? throw new NotFoundException("Report Reason not found.");

            return new BaseResponseDTO<ReportReasonDto>().AddContent(new ReportReasonDto(reason));
        }

        public async Task<BaseResponseDTO<ReportDto>> GetReports()  
        {
            var reports = await _reportRepository.GetAll() ?? throw new NotFoundException("Reports not found.");

            return new BaseResponseDTO<ReportDto>().AddContent(reports.Select(x => new ReportDto(x)));
        }
    }
}
