using System;
using System.Linq;
using UniAssist.Database;
using UniAssist.Entities;

namespace UniAssist.Services
{
    /// <summary>
    /// Config Service
    /// </summary>
    public class ConfigService : IConfigService
    {
        private readonly ApplicationDbContext _context;
        
        private const string WorkingDirectoryName = "working-directory";

        /// <summary>
        /// Initialize Config Service 
        /// </summary>
        /// <param name="context">Database Context</param>
        public ConfigService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Get Config parameter by name
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <typeparam name="T">Type of parameter</typeparam>
        /// <returns>The config if the value is convertible or a default value</returns>
        private T GetConfig<T>(string name)
        {
            Config conf = this._context.Config.FirstOrDefault(x => x.Name == name);

            if (conf == null)
            {
                return default;
            }

            if (typeof(T).ToString() == conf.Type)
            {
                return (T) Convert.ChangeType(conf.Value, typeof(T));
            }

            return default;
        }

        /// <inheritdoc />
        public string GetWorkingDirectory()
        {
            return this.GetConfig<string>(WorkingDirectoryName);
        }

        /// <inheritdoc />
        public bool WorkingDirectoryExist()
        {
            return !string.IsNullOrEmpty(this.GetWorkingDirectory());
        }

        /// <inheritdoc />
        public void SetWorkingDirectory(string value)
        {
            Config conf = this._context.Config.FirstOrDefault(x => x.Name == WorkingDirectoryName);

            if (conf == null)
            {
                conf = new Config
                {
                    Name = WorkingDirectoryName,
                    Type = typeof(string).ToString(),
                    Value = value
                };

                this._context.Config.Add(conf);
                this._context.SaveChanges();
            }
            else
            {
                conf.Value = value;

                this._context.Config.Update(conf);
                this._context.SaveChanges();
            }
        }
    }
}