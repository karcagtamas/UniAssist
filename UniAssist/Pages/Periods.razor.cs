using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using UniAssist.Entities;
using UniAssist.Services;

namespace UniAssist.Pages
{
    /// <summary>
    /// Periods Page
    /// </summary>
    public partial class Periods
    {
        [Inject]
        private IPeriodService PeriodService { get; set; }
        
        private List<Period> PeriodList { get; set; }

        /// <summary>
        /// Initialize Periods Page
        /// </summary>
        protected override void OnInitialized()
        {
            this.PeriodList = this.PeriodService.GetAll().ToList();
        }
    }
}