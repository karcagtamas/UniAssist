using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniAssist.Models;

namespace UniAssist.Entities
{
    /// <summary>
    /// Folder entity
    /// </summary>
    public class Folder : IEntity
    {
        /// <value>
        /// Folder Id
        /// </value>
        [Key]
        public string Id { get; set; }
        
        /// <value>
        /// Folder Id
        /// </value>
        [Required]
        public string Name { get; set; }
        
        /// <value>
        /// Parent Folder Id
        /// </value>
        public string ParentFolderId { get; set; }
        
        /// <value>
        /// Subject Id
        /// </value>
        public string SubjectId { get; set; }
        
        /// <value>
        /// Parent folder
        /// </value>
        public virtual Folder ParentFolder { get; set; }
        
        /// <value>
        /// Subject folder
        /// </value>
        public virtual Subject Subject { get; set; }
        
        /// <value>
        /// Subfolders
        /// </value>
        public virtual ICollection<Folder> SubFolders { get; set; }
        
        /// <value>
        /// Files
        /// </value>
        public virtual ICollection<File> Files { get; set; }
    }
}