using MKW.Domain.Entities.Base;

namespace MKW.Domain.Entities.ContentAggregate
{
    /// <summary>
    /// Entidade que representa o Gênero do Conteúdo apresentado.
    /// Exemplo: Comédia, Terror, Ação, etc.
    /// </summary>
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<ContentGenre> ContentGenre { get; set; }
    }
}
