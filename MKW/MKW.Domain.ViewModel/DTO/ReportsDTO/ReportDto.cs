using MKW.Domain.Dto.DTO.CommentDTO;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Entities.ReportAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.ReportsDTO
{
    public class ReportDto
    {
        public int ReportId { get; set; }
        public int ReasonId { get; set; }
        public int? ReviewId { get; set; }
        public int? CommentId { get; set; }
        public string? Details { get; set; }
        public ReportReasonDto Reason { get; set; }
        public ReviewDto? Review { get; set; }
        public CommentDetailsDto? Comment { get; set; }

        public ReportDto()
        {

        }

        public ReportDto(Report report) : this()
        {
            ReportId = report.Id;
            ReviewId = report.ReviewId;
            CommentId = report.CommentId;
            ReasonId = report.ReasonId;
            Reason = new ReportReasonDto(report.Reason);
            Review = report.Review != null ? new ReviewDto(report.Review) : null;
            Comment = report.Comment != null ? new CommentDetailsDto(report.Comment) : null;
        }
    }
}
