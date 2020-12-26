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
        
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        
        private List<Period> PeriodList { get; set; }
        private bool IsAdding { get; set; }

        /// <summary>
        /// Initialize Periods Page
        /// </summary>
        protected override void OnInitialized()
        {
            this.PeriodList = this.PeriodService.GetAll().ToList();
        }

        private void OpenHome()
        {
            this.NavigationManager.NavigateTo("/");
        }

        private void Add()
        {
            this.IsAdding = true;
        }

        private void CancelAdding()
        {
            this.IsAdding = false;
        }

        private void SaveAdding()
        {
            this.IsAdding = false;
        }
    }
}