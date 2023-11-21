using MKW.Domain.Entities.ReportAggregate;
using MKW.Domain.Utility.Language.Report;

namespace MKW.Domain.Dto.DTO.ReportsDTO
{
    public class ReportReasonDto
    {
        public int ReasonId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ReportReasonDto()
        {

        }

        public ReportReasonDto(ReportReason reason, string language = "pt-BR")
        {
            ReasonId = reason.Id;
            Title = ReportLangHelper.GetReason(reason.Title, language);
            Description = ReportLangHelper.GetReason(reason.Description, language);
        }
    }
}
