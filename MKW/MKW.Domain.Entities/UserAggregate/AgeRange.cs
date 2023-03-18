﻿using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.UserAggregate
{
    public class AgeRange : BaseEntity
    {
        public int InitialAge { get; set; }
        public int FinalAge { get; set; }
        public ICollection<PersonChild> Children { get; set; }
    }
}
