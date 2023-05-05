using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Dto.IdentityDTO
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
        public  bool LockoutEnabled { get; set; }
        public  bool LockoutEnd { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? AlterDate { get; set; }
        public bool Active { get; set; }
        public  string confirmEmailToken { get; set; }
    }
}
