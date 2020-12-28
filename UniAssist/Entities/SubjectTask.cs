using System.ComponentModel.DataAnnotations;

namespace UniAssist.Entities
{
    /// <summary>
    /// Subject Task entity
    /// </summary>
    public class SubjectTask : Task
    {
        /// <value>
        /// Subject Id
        /// </value>
        [Required]
        public string SubjectId { get; set; }
        
        /// <value>
        /// Subject
        /// </value>
        public virtual Subject Subject { get; set; }
    }
}