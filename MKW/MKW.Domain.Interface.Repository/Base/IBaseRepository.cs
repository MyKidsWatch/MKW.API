using MKW.Domain.Entities.Base;
using MKW.Domain.Utility.Abstractions;
using System.Linq.Expressions;

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
        /// 
        /// </summary>
        /// <param name="predicate">Função de busca de entidades</param>
        /// <param name="pageSize">Tamanho das páginas</param>
        /// <param name="page">Página a ser buscada</param>
        /// <returns></returns>
        Task<PagedList<TEntity>> GetPaged<TKey>(Expression<Func<TEntity, bool>>? predicate = null, int page = 1, int pageSize = 10, Func<TEntity, TKey>? order = null, bool asc = true);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate">Função de busca de entidades</param>
        /// <param name="pageSize">Tamanho das páginas</param>
        /// <param name="page">Página a ser buscada</param>
        /// <returns></returns>
        Task<PagedList<TEntity>> GetPaged(Expression<Func<TEntity, bool>>? predicate = null, int page = 1, int pageSize = 10);
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
        /// Método que Adiciona as Entidades na Base de Dados.
        /// </summary>
        /// <param name="entities">Entidadse a serem Inseridas na Base.</param>
        Task AddRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// Método que Adiciona as Entidades na Base de Dados.
        /// </summary>
        /// <param name="entities">Entidades a serem Inseridas na Base.</param>
        Task AddRange(params TEntity[] entities);
        /// <summary>
        /// Método que Atualiza as Entidades na Base de Dados, com base em suas Chaves Primárias ou Tracking.
        /// </summary>
        /// <param name="entities">Entidades a serem Atualizadas na Base.</param>
        Task UpdateRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// Método que Atualiza as Entidades na Base de Dados, com base em suas Chaves Primárias ou Tracking.
        /// </summary>
        /// <param name="entities">Entidadse a serem Atualizadas na Base.</param>
        Task UpdateRange(params TEntity[] entities);
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
