using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using UniAssist.Entities;

namespace UniAssist.Models
{
    /// <summary>
    /// Period Model
    /// </summary>
    public class PeriodModel
    {
        /// <value>
        /// Period Id.
        /// </value>
        public string Id { get; set; }
        
        /// <value>
        /// Period Name.
        /// </value>
        [StringLength(80, ErrorMessage = "Maximum length is 80")]
        [Required(ErrorMessage = "Field is required")]
        public string Name { get; set; }
        
        /// <value>
        /// Period folder name
        /// </value>
        [Required(ErrorMessage = "Field is required")]
        [StringLength(20, ErrorMessage = "Maximum length is 20")]
        public string FolderName { get; set; }

        /// <summary>
        /// Initialize empty Period
        /// </summary>
        public PeriodModel()
        {
            
        }

        /// <summary>
        /// Initialize Period Model from Period
        /// </summary>
        /// <param name="period">Period</param>
        public PeriodModel([NotNull]Period period)
        {
            this.Id = period.Id;
            this.Name = period.Name;
            this.FolderName = period.FolderName;
        }
    }
}