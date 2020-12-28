using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniAssist.Models;

namespace UniAssist.Entities
{
    /// <summary>
    /// Period Entity
    /// </summary>
    public class Period : IEntity
    {
        /// <value>
        /// Period Id.
        /// </value>
        [Key]
        public string Id { get; set; }
        
        /// <value>
        /// Period Name.
        /// </value>
        [StringLength(80)]
        [Required]
        public string Name { get; set; }
        
        /// <value>
        /// Period folder name
        /// </value>
        [Required]
        [StringLength(20)]
        public string FolderName { get; set; }
        
        /// <value>
        /// Subjects
        /// </value>
        public virtual ICollection<Subject> Subjects { get; set; }
        
        /// <value>
        /// Notes
        /// </value>
        public virtual ICollection<PeriodNote> Notes { get; set; }
        
        /// <value>
        /// Period tasks
        /// </value>
        public virtual ICollection<PeriodTask> Tasks { get; set; }
    }
}