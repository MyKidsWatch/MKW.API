using MKW.Domain.Entities.ReportAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ReportReasonDto(ReportReason reason)
        {
            ReasonId = reason.Id;
            Title = reason.Title;
            Description = reason.Description;
        }
    }
}
