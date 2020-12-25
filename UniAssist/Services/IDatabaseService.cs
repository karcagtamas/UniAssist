using System.Collections.Generic;
using System.Linq;
using UniAssist.Models;

namespace UniAssist.Services
{
    /// <summary>
    /// Database Service Interface
    /// </summary>
    public interface IDatabaseService<T> where T : class, IEntity
    {
        /// <summary>
        /// Get Entity.
        /// </summary>
        /// <returns>Entity as the given type</returns>
        T Get<TK>(TK id);

        /// <summary>
        /// Get All Entity.
        /// </summary>
        /// <returns>Entity Collection.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Add Entity.
        /// </summary>
        /// <param name="value">Entity value</param>
        void Add(T value);

        /// <summary>
        /// Update Entity.
        /// </summary>
        /// <param name="value">Entity value</param>
        void Update(T value);

        /// <summary>
        /// Delete Entity.
        /// </summary>
        /// <param name="value">Entity value</param>
        void Delete(T value);

        /// <summary>
        /// Commit changes.
        /// </summary>
        void Commit();
    }
}