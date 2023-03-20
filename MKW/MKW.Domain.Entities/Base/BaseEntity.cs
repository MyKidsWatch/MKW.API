namespace MKW.Domain.Entities.Base
{
    /// <summary>
    /// Entidade Base que contém propriedades comuns à todas as Entidades do Sistema.
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }
        public Guid? UUID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? AlterDate { get; set; }
        public bool Active { get; set; } = true;
    }
}
