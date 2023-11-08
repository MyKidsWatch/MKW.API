using System.ComponentModel.DataAnnotations;

namespace MKW.Domain.Dto.DTO.ReportsDTO
{
    public class CreateReportDto
    {
        public int? ReportedPersonId { get; set; }
        public int ReasonId { get; set; }
        public int? CommentId { get; set; }
        public int? ReviewId { get; set; }
        [MaxLength(500)]
        public string? Details { get; set; }
    }
}
