using Microsoft.AspNetCore.Identity;

namespace MKW.Domain.Entities.IdentityAggregate
{
    //TODO: Alterar para GUID ou UUID
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? AlterDate { get; set; }
        public bool Active { get; set; } = true;
    }
}
