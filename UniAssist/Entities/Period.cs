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
    }
}