using UniAssist.Database;
using UniAssist.Entities;

namespace UniAssist.Services
{
    /// <summary>
    /// Period Service
    /// </summary>
    public class PeriodService : DatabaseService<Period>, IPeriodService
    {
        /// <summary>
        /// Initialize Period Service
        /// </summary>
        /// <param name="context">Database Context</param>
        public PeriodService(ApplicationDbContext context) : base(context)
        {
        }
    }
}