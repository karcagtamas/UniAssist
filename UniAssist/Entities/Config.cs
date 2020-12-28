using System.ComponentModel.DataAnnotations;

namespace UniAssist.Entities
{
    /// <summary>
    /// Config Entity
    /// </summary>
    public class Config
    {
        /// <value>
        /// Config parameter name.
        /// </value>
        [Key]
        public string Name { get; set; }
        
        /// <value>
        /// Config parameter type.
        /// </value>
        [Required]
        [StringLength(16)]
        public string Type { get; set; }
        
        /// <value>
        /// Config parameter value.
        /// </value>
        [Required]
        [StringLength(120)]
        public string Value { get; set; }
    }
}