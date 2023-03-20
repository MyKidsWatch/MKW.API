using MKW.Domain.Entities.Base;

namespace MKW.Domain.Interface.Repository.Base
{
    /// <summary>
    /// Repositório de Base que adiciona operações de CRUD para a TEntity informada.
    /// Disponibiliza também a propriedade _dbSet para acesso à Tabela equivalente à TEntity na Base de Dados.
    /// </summary>
    /// <typeparam name="TEntity">Entidade que herda da BaseEntity</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Método de Listagem de Todas as Entidades.
        /// </summary>
        /// <returns>Lista de Entidades</returns>
        Task<IEnumerable<TEntity>?> GetAll();
        /// <summary>
        /// Método de Listagem de Todas as Entidades Ativas.
        /// </summary>
        /// <returns>Lista de Entidades</returns>
        Task<IEnumerable<TEntity>?> GetActive();
        /// <summary>
        /// Método de Busca de Entidade por Id.
        /// </summary>
        /// <param name="id">Id da Entidade</param>
        /// <returns>Entidade</returns>
        Task<TEntity?> GetById(int id);
        /// <summary>
        /// Método de Busca por UUID
        /// </summary>
        /// <param name="uuid">Identificador Universal Único da Entidade</param>
        /// <returns>Entidade</returns>
        Task<TEntity?> GetByUUID(Guid uuid);
        /// <summary>
        /// Método que Adiciona a Entidade na Base de Dados.
        /// </summary>
        /// <param name="entity">Entidade a ser Inserida na Base.</param>
        /// <returns>A própria Entidade, após inserida.</returns>
        Task<TEntity> Add(TEntity entity);
        /// <summary>
        /// Método que Atualiza a Entidade na Base de Dados, com base em suas Chaves Primárias ou Tracking.
        /// </summary>
        /// <param name="entity">Entidade a ser Atualizada na Base.</param>
        /// <returns>A própria Entidade, após atualizada.</returns>
        Task<TEntity> Update(TEntity entity);
        /// <summary>
        /// Método que Desativa a Entidade na Base de Dados, com base em suas Chaves Primárias ou Tracking.
        /// </summary>
        /// <param name="entity">Entidade a ser Excluída</param>
        /// <returns></returns>
        Task Delete(TEntity entity);
        /// <summary>
        /// Método que Desativa a Entidade na Base de Dados, com base no Id fornecido.
        /// </summary>
        /// <param name="id">Id da Entidade a ser Excluída</param>
        /// <returns></returns>
        Task DeleteById(int id);
        /// <summary>
        /// Método que Desativa a Entidade na Base de Dados, com base no UUID fornecido.
        /// </summary>
        /// <param name="uuid">Identificador Universal Único da Entidade a ser Excluída</param>
        /// <returns></returns>
        Task DeleteByUUID(Guid uuid);
    }
}
