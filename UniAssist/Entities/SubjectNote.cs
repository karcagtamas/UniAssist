using System.ComponentModel.DataAnnotations;

namespace UniAssist.Entities
{
    /// <summary>
    /// Subject Note
    /// </summary>
    public class SubjectNote : Note
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