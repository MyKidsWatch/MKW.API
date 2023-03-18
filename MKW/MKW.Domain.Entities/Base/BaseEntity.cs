namespace MKW.Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Guid? UUID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? AlterDate { get; set; }
        public bool Active { get; set; } = true;
    }
}
