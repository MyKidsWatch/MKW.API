using MKW.Domain.Entities.ReportAggregate;

namespace MKW.Domain.Dto.DTO.ReportsDTO
{
    public class ReportStatusDto
    {
        public int StatusId { get; set; }
        public string Name { get; set; }

        public ReportStatusDto()
        {

        }

        public ReportStatusDto(ReportStatus status) : this()
        {
            StatusId = status.Id;
            Name = status.Name;
        }
    }
}
