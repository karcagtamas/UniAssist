using System.ComponentModel.DataAnnotations;

namespace UniAssist.Entities
{
    /// <summary>
    /// Period Note
    /// </summary>
    public class PeriodNote : Note
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