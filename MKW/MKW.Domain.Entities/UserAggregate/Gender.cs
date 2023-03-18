using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.UserAggregate
{
    public class Gender : BaseEntity
    {
        public string Name { get; set; }
        public bool IsBinary { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<PersonChild> Children { get; set; }
    }
}
