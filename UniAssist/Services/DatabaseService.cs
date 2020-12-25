using System.Collections.Generic;
using System.Linq;
using UniAssist.Database;
using UniAssist.Models;

namespace UniAssist.Services
{
    /// <summary>
    /// Database Service
    /// </summary>
    /// <typeparam name="T">Type param</typeparam>
    public class DatabaseService<T> : IDatabaseService<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initialize Database Service
        /// </summary>
        /// <param name="context">Database Context</param>
        public DatabaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public T Get<TK>(TK id)
        {
            return this._context.Set<T>().Find(id);
        }

        /// <inheritdoc />
        public IEnumerable<T> GetAll()
        {
            return this._context.Set<T>().ToList();
        }

        /// <inheritdoc />
        public void Add(T value)
        {
            this._context.Set<T>().Add(value);
            this.Commit();
        }

        /// <inheritdoc />
        public void Update(T value)
        {
            this._context.Set<T>().Update(value);
            this.Commit();
        }
        
        /// <inheritdoc />
        public void Delete(T value)
        {
            this._context.Set<T>().Remove(value);
            this.Commit();
        }

        /// <inheritdoc />
        public void Commit()
        {
            this._context.SaveChanges();
        }
    }
}