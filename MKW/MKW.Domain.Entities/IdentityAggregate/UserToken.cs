using MKW.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Entities.IdentityAggregate
{
    public class UserToken
    {
        public int UserId { get; set; }
        public int KeyCode { get; set; }
        public string Token { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
