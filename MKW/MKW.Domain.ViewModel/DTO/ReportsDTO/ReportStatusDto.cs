using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Utility.Language.Report;

namespace MKW.Domain.Dto.DTO.ReportsDTO
{
    public class ReportStatusDto
    {
        public int StatusId { get; set; }
        public string Name { get; set; }

        public ReportStatusDto()
        {

        }

        public ReportStatusDto(ReportStatus status, string language = "pt-BR") : this()
        {
            StatusId = status.Id;
            Name = ReportLangHelper.GetStatus(status.Name, language);
        }
    }
}
