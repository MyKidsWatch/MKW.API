using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReportsDTO;
using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using MKW.Domain.Interface.Repository.ReportAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Utility.Abstractions;
using MKW.Domain.Utility.Exceptions;

namespace MKW.Services.AppServices
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IReportReasonRepository _reportReasonRepository;
        private readonly IReportStatusRepository _reportStatusRepository;
        private readonly IPersonService _personService;
        private readonly IReviewRepository _reviewRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;

        public ReportService(IReportRepository reportRepository, IReportReasonRepository reportReasonRepository,
                             IPersonService personService, IReportStatusRepository reportStatusRepository,
                             IReviewRepository reviewRepository, ICommentRepository commentRepository,
                             IUserRepository userRepository)
        {
            _reportRepository = reportRepository;
            _reportReasonRepository = reportReasonRepository;
            _personService = personService;
            _reportStatusRepository = reportStatusRepository;
            _reviewRepository = reviewRepository;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task<BaseResponseDTO<ReportReasonDto>> GetReasons()
        {
            var reasons = await _reportReasonRepository.GetActive();

            return new BaseResponseDTO<ReportReasonDto>().AddContent(reasons.Select(x => new ReportReasonDto(x)));
        }


        public async Task<BaseResponseDTO<ReportStatusDto>> GetStatus()
        {
            var status = await _reportStatusRepository.GetActive();

            return new BaseResponseDTO<ReportStatusDto>().AddContent(status.Select(x => new ReportStatusDto(x)));
        }

        public async Task<BaseResponseDTO<ReportReasonDto>> GetReasonById(int id)
        {
            var reason = await _reportReasonRepository.GetById(id) ?? throw new NotFoundException("Report Reason not found.");

            return new BaseResponseDTO<ReportReasonDto>().AddContent(new ReportReasonDto(reason));
        }

        public async Task<BaseResponseDTO<ReportDto>> GetReports(int page = 1, int pageSize = 10, int? reasonId = null, int? statusId = null,
                                                                 string orderBy = "CreateDate", bool orderByAscending = true)
        {
            var reports = await _reportRepository.GetPaged(x =>
                                                            (reasonId == null || x.ReasonId == reasonId)
                                                            && (statusId == null || x.StatusId == statusId)
                                                            && x.Active,
                                                            page, pageSize,
                                                            x => x.GetType().GetProperty(orderBy)?.GetValue(x) ?? x.CreateDate,
                                                            orderByAscending);

            var reportsDto = new PagedList<ReportDto>().Convert(reports, x => new ReportDto(x));

            return new BaseResponseDTO<ReportDto>().AddContent(reportsDto);
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

        public async Task<BaseResponseDTO<ReportDto>> RespondReport(ReportResponseDto model)
        {
            var report = await _reportRepository.GetById(model.ReportId) ?? throw new NotFoundException("Report not found.");

            report.StatusId = model.StatusId ?? report.StatusId;
            if (model.CloseReport) report.Active = false;
            await _reportRepository.Update(report);

            if (report.CommentId != null && model.DeleteComment) await _commentRepository.DeleteById(report.CommentId ?? 0);
            if (report.ReviewId != null && model.DeleteReview) await _reviewRepository.DeleteById(report.ReviewId ?? 0);
            if (model.DeletePerson)
            {
                var person =
                    report.ReportedPersonId != null
                        ? report.ReportedPerson!
                        : report.ReviewId != null
                            ? report.Review!.Person
                            : report.CommentId != null
                                ? report.Comment!.Person
                                : null;

                await _userRepository.DeleteUserByIdAsync(person.UserId);
                await _personService.Delete(person.Id);
            }

            return new BaseResponseDTO<ReportDto>().AddContent(new ReportDto(report));
        }
    }
}
