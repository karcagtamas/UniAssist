using System.ComponentModel.DataAnnotations;

namespace UniAssist.Entities
{
    public class Period
    {
        [Key]
        public string Id { get; set; }
        
        [StringLength(80)]
        [Required]
        public string Name { get; set; }
    }
}