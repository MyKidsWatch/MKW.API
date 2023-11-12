namespace MKW.Domain.Dto.DTO.ReportsDTO
{
    public class ReportResponseDto
    {
        public int ReportId { get; set; }
        public int? StatusId { get; set; } = null;
        public bool DeleteComment { get; set; } = false;
        public bool DeleteReview { get; set; } = false;
        public bool DeletePerson { get; set; } = false;
        public bool CloseReport { get; set; } = false;
    }
}
