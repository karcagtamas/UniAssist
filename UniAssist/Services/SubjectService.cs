using UniAssist.Database;
using UniAssist.Entities;

namespace UniAssist.Services
{
    /// <summary>
    /// Subject Service
    /// </summary>
    public class SubjectService : DatabaseService<Subject>, ISubjectService
    {
        /// <summary>
        /// Initialize Subject Service
        /// </summary>
        /// <param name="context">Database Context</param>
        public SubjectService(ApplicationDbContext context) : base(context)
        {
        }
    }
}