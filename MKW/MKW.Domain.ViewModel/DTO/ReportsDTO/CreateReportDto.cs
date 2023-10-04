using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.ReportsDTO
{
    public class CreateReportDto
    {
        public int ReasonId { get; set; }
        public int? CommentId { get; set; }
        public int? ReviewId { get; set; }
        [MaxLength(500)]
        public string? Details { get; set; }
    }
}
