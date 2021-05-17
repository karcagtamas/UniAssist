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
        /// <summary>
        /// Database Context
        /// </summary>
        protected readonly ApplicationDbContext Context;

        /// <summary>
        /// Initialize Database Service
        /// </summary>
        /// <param name="context">Database Context</param>
        public DatabaseService(ApplicationDbContext context)
        {
            Context = context;
        }

        /// <inheritdoc />
        public virtual T Get<TK>(TK id)
        {
            return this.Context.Set<T>().Find(id);
        }

        /// <inheritdoc />
        public virtual IEnumerable<T> GetAll()
        {
            return this.Context.Set<T>().ToList();
        }

        /// <inheritdoc />
        public virtual void Add(T value)
        {
            this.Context.Set<T>().Add(value);
            this.Commit();
        }

        /// <inheritdoc />
        public virtual void Update(T value)
        {
            this.Context.Set<T>().Update(value);
            this.Commit();
        }
        
        /// <inheritdoc />
        public virtual void Delete(T value)
        {
            this.Context.Set<T>().Remove(value);
            this.Commit();
        }

        /// <inheritdoc />
        public virtual void Commit()
        {
            this.Context.SaveChanges();
        }
    }
}