using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using UniAssist.Entities;

namespace UniAssist.Models
{
    /// <summary>
    /// Subject Model
    /// </summary>
    public class SubjectModel
    {
        /// <value>
        /// Subject Id
        /// </value>
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
        /// Result mark of subject
        /// </value>
        public int? Result { get; set; }
        
        /// <summary>
        /// Initialize empty Subject
        /// </summary>
        public SubjectModel()
        {
            
        }

        /// <summary>
        /// Initialize Subject Model from Subject
        /// </summary>
        /// <param name="subject">Subject</param>
        public SubjectModel([NotNull]Subject subject)
        {
            this.Id = subject.Id;
            this.LongName = subject.LongName;
            this.ShortName = subject.ShortName;
            this.Code = subject.Code;
            this.Description = subject.Description;
            this.Credit = subject.Credit;
            this.FolderName = subject.FolderName;
            this.Result = subject.Result;
        }
    }
}