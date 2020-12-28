using System;
using System.ComponentModel.DataAnnotations;
using UniAssist.Models;

namespace UniAssist.Entities
{
    /// <summary>
    /// File Entity
    /// </summary>
    public class File : IEntity
    {
        /// <value>
        /// File Id
        /// </value>
        [Key]
        public string Id { get; set; }
        
        /// <value>
        /// File name
        /// </value>
        [Required]
        public string Name { get; set; }
        
        /// <value>
        /// File extension
        /// </value>
        [Required]
        [StringLength(10)]
        public string Extension { get; set; }
        
        /// <value>
        /// File parent folder's path
        /// </value>
        [Required]
        public string Path { get; set; }
        
        /// <value>
        /// File creation date
        /// </value>
        [Required]
        public DateTime Creation { get; set; }
        
        /// <value>
        /// File last update
        /// </value>
        [Required]
        public DateTime LastUpdate { get; set; }
        
        /// <value>
        /// File content
        /// </value>
        [Required]
        public byte[] Content { get; set; }
        
        /// <value>
        /// Parent folder Id
        /// </value>
        public string ParentFolderId { get; set; }
        
        /// <value>
        /// Subject Id
        /// </value>
        public string SubjectId { get; set; }
        
        /// <value>
        /// File parent folder
        /// </value>
        public virtual Folder ParentFolder { get; set; }
        
        /// <value>
        /// Subject
        /// </value>
        public virtual Subject Subject { get; set; }
    }
}