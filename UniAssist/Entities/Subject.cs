using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniAssist.Models;

namespace UniAssist.Entities
{
    /// <summary>
    /// Subject Entity
    /// </summary>
    public class Subject : IEntity
    {
        /// <value>
        /// Subject Id
        /// </value>
        [Key]
        public string Id { get; set; }
        
        /// <value>
        /// Subject long name
        /// </value>
        [Required(ErrorMessage = "Field is required")]
        [StringLength(100, ErrorMessage = "Max length is 100")]
        public string LongName { get; set; }
        
        /// <value>
        /// Subject short name
        /// </value>
        [Required(ErrorMessage = "Field is required")]
        [StringLength(20, ErrorMessage = "Max length is 20")]
        public string ShortName { get; set; }
        
        /// <value>
        /// Subject code
        /// </value>
        [Required(ErrorMessage = "Field is required")]
        [StringLength(10, ErrorMessage = "Max length is 10")]
        public string Code { get; set; }
        
        /// <value>
        /// Subject description
        /// </value>
        public string Description { get; set; }
        
        /// <value>
        /// Subject credit value
        /// </value>
        [Required(ErrorMessage = "Field is required")]
        public int Credit { get; set; }

        /// <value>
        /// Subject folder name
        /// </value>
        [Required(ErrorMessage = "Field is required")]
        [StringLength(20, ErrorMessage = "Max length is 20")]
        public string FolderName { get; set; }
        
        /// <value>
        /// Period Id
        /// </value>
        [Required(ErrorMessage = "Field is required")]
        public string PeriodId { get; set; }
        
        /// <value>
        /// Result mark of subject
        /// </value>
        public int? Result { get; set; }
        
        /// <value>
        /// Period
        /// </value>
        public virtual Period Period { get; set; }
        
        /// <value>
        /// Subject files
        /// </value>
        public virtual ICollection<File> Files { get; set; }
        
        /// <value>
        /// Subject folders
        /// </value>
        public virtual ICollection<Folder> Folders { get; set; }
        
        /// <value>
        /// Subject notes
        /// </value>
        public virtual ICollection<SubjectNote> Notes { get; set; }
        
        /// <value>
        /// Subject tasks
        /// </value>
        public virtual ICollection<SubjectTask> Tasks { get; set; }

        /// <summary>
        /// Initialize Subject Entity
        /// </summary>
        public Subject()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initialize Subject Entity with Period
        /// </summary>
        /// <param name="period">Subject Period</param>
        public Subject(Period period)
        {
            this.Id = Guid.NewGuid().ToString();
            this.PeriodId = period.Id;
        }
    }
}