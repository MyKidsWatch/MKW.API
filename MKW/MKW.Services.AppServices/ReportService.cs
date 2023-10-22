using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReportsDTO;
using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Interface.Repository.ReportAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Exceptions;

namespace MKW.Services.AppServices
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IReportReasonRepository _reportReasonRepository;
        private readonly IReportStatusRepository _reportStatusRepository;
        private readonly IPersonService _personService;

        public ReportService(IReportRepository reportRepository, IReportReasonRepository reportReasonRepository, IPersonService personService, IReportStatusRepository reportStatusRepository)
        {
            _reportRepository = reportRepository;
            _reportReasonRepository = reportReasonRepository;
            _personService = personService;
            _reportStatusRepository = reportStatusRepository;
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

        public async Task<BaseResponseDTO<ReportDto>> AddReport(CreateReportDto model)
        {
            var user = await _personService.GetUser();
            if (await _reportRepository.AnyReportByUser(user.Id, model.ReviewId, model.CommentId, model.ReportedPersonId)) throw new BadRequestException("User has already reported this post.");

            if (user.Id == model.ReportedPersonId) throw new BadRequestException("User cannot report itself.");

            var reason = await _reportReasonRepository.GetById(model.ReasonId) ?? throw new NotFoundException("Reason not found");
            var reportStatus = await _reportStatusRepository.GetByName("Análise Pendente");

            var report = new Report()
            {
                ReasonId = reason.Id,
                PersonId = user.Id,
                ReportedPersonId = model.ReportedPersonId,
                StatusId = reportStatus.Id,
                CommentId = model.CommentId,
                ReviewId = model.ReviewId,
                Details = model.Details,
            };

            report = await _reportRepository.Add(report);

            return new BaseResponseDTO<ReportDto>().AddContent(new ReportDto(report));
        }

        public async Task<BaseResponseDTO<ReportDto>> UpdateReportStatus(UpdateReportStatusDto model)
        {
            var report = await _reportRepository.GetById(model.ReportId) ?? throw new NotFoundException("Report not found.");

            report.StatusId = model.StatusId;

            await _reportRepository.Update(report);

            return new BaseResponseDTO<ReportDto>().AddContent(new ReportDto(report));
        }
    }
}
