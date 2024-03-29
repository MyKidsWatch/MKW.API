﻿using MKW.Domain.Dto.DTO.PersonDTO;
using System.Text.Json.Serialization;

namespace MKW.Domain.Dto.DTO.IdentityDTO.Account
{
    public class ReadUserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string userName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public bool IsAdminUser { get; set; } = false;
        public DateTimeOffset LockoutEnd { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? AlterDate { get; set; }
        public bool Active { get; set; }
        public bool isConfirmEmailTokenSent { get; set; }
        public ReadPersonDTO AssociatedWithPerson { get; set; }
    }
}
