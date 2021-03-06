using System.ComponentModel.DataAnnotations;

namespace UniAssist.Entities
{
    /// <summary>
    /// Period Task entity
    /// </summary>
    public class PeriodTask : Task
    {
        /// <value>
        /// Period Id
        /// </value>
        [Required]
        public string PeriodId { get; set; }
        
        /// <value>
        /// Period
        /// </value>
        public virtual Period Period { get; set; }
    }
}