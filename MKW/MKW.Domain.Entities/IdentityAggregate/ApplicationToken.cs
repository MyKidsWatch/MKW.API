﻿using System;
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
            Token = value;
            ExpirationDate = expirationDate;
        }
        public string Token { get; }
        public DateTime ExpirationDate { get; }
    }
}