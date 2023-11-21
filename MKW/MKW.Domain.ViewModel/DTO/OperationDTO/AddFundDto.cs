using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.OperationDTO
{
    public class AddFundDto
    {
        public int Coins { get; set; }
        public string Language { get; set; } = "pt-BR";
    }
}
