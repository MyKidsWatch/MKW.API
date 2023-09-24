using MKW.Domain.Entities.ReportAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
