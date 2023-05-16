﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class RequestKeycodeDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
