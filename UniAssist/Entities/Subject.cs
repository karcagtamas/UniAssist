using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniAssist.Entities
{
    /// <summary>
    /// Subject Entity
    /// </summary>
    public class Subject
    {
        /// <value>
        /// Subject Id
        /// </value>
        [Key]
        public string Id { get; set; }
        
        /// <value>
        /// Subject long name
        /// </value>
        [Required]
        [StringLength(100)]
        public string LongName { get; set; }
        
        /// <value>
        /// Subject short name
        /// </value>
        [Required]
        [StringLength(20)]
        public string ShortName { get; set; }
        
        /// <value>
        /// Subject code
        /// </value>
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        
        /// <value>
        /// Subject description
        /// </value>
        public string Description { get; set; }
        
        /// <value>
        /// Subject credit value
        /// </value>
        public int Credit { get; set; }
        
        /// <value>
        /// Subject status
        /// </value>
        public string Status { get; set; }
        
        /// <value>
        /// Subject folder name
        /// </value>
        [Required]
        [StringLength(20)]
        public string FolderName { get; set; }
        
        /// <value>
        /// Subject notes
        /// </value>
        public virtual ICollection<SubjectNote> Notes { get; set; }
    }
}