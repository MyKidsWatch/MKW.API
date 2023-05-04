using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Entities.IdentityAggregate
{
    public class ApplicationToken
    {
        public ApplicationToken(string value, DateTime expirationDate)
        {
            Value = value;
            ExpirationDate = expirationDate;
        }
        public string Value { get; }
        public DateTime ExpirationDate { get; }
    }
}
