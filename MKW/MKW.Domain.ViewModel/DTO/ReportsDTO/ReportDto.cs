using MKW.Domain.Dto.DTO.CommentDTO;
using MKW.Domain.Dto.DTO.PersonDTO;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Entities.ReportAggregate;

namespace MKW.Domain.Dto.DTO.ReportsDTO
{
    public class ReportDto
    {
        public int ReportId { get; set; }
        public int ReasonId { get; set; }
        public int PersonId { get; set; }
        public int? ReportedPersonId { get; set; }
        public int? ReviewId { get; set; }
        public int? CommentId { get; set; }
        public int? StatusId { get; set; }
        public string? Details { get; set; }
        public string? ReportType { get; set; }
        public DateTime CreateDate { get; set; }
        public ReportReasonDto Reason { get; set; }
        public ReviewDto? Review { get; set; }
        public CommentDetailsDto? Comment { get; set; }
        public ReadPersonDTO Person { get; set; }
        public ReadPersonDTO? ReportedPerson { get; set; }
        public ReportStatusDto Status { get; set; }

        public ReportDto()
        {

        }

        public ReportDto(Report report, string language = "pt-BR") : this()
        {
            ReportId = report.Id;
            ReviewId = report.ReviewId;
            CommentId = report.CommentId;
            PersonId = report.PersonId;
            ReasonId = report.ReasonId;
            StatusId = report.StatusId;
            ReportedPersonId = report.ReportedPersonId;
            Details = report.Details;
            Reason = new ReportReasonDto(report.Reason, language);
            Review = report.Review != null ? new ReviewDto(report.Review) : null;
            Comment = report.Comment != null ? new CommentDetailsDto(report.Comment) : null;
            Person = new ReadPersonDTO(report.Person);
            ReportedPerson = report.ReportedPerson != null ? new ReadPersonDTO(report.ReportedPerson) : null;
            Status = new ReportStatusDto(report.Status, language);
            CreateDate = report.CreateDate;

            if (report.CommentId != null) ReportType = language == "pt-BR" ? "Comentário" : "Comment";
            else if (report.ReviewId != null) ReportType = language == "pt-BR" ? "Análise" : "Review";
            else if (report.ReportedPersonId != null) ReportType = language == "pt-BR" ? "Perfil" : "Person";
            else ReportType = null;
        }
    }
}
