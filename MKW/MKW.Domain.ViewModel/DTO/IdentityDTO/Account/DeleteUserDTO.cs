﻿using System.ComponentModel.DataAnnotations;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class DeleteUserDTO
    {
        public int? Id { get; set; }

        [MaxLength(12, ErrorMessage = "Max length 12")]
        [MinLength(3, ErrorMessage = "min length 2")]
        public string? UserName { get; set; }

        [EmailAddress(ErrorMessage = "The field {0} is invalid")]
        public string? Email { get; set; }
    }
}
