using MKW.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.GenderDTO
{
    public class GenderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsBinary { get; set; }

        public GenderDto(Gender gender)
        {
            Id = gender.Id;
            Name = gender.Name;
            IsBinary = gender.IsBinary;
        }
    }
}
