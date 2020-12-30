using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using UniAssist.Entities;
using UniAssist.Models;
using UniAssist.Services;

namespace UniAssist.Pages
{
    /// <summary>
    /// Periods Page
    /// </summary>
    public partial class PeriodList
    {
        [Inject]
        private IPeriodService PeriodService { get; set; }
        
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private List<Period> Periods { get; set; } = new();
        private bool IsAdding { get; set; }
        private PeriodModel PeriodModel { get; set; } = new();
        private EditContext PeriodContext { get; set; }

        /// <summary>
        /// Initialize Periods Page
        /// </summary>
        protected override void OnInitialized()
        {
            this.GetPeriods();
            this.PeriodContext = new EditContext(PeriodModel);
        }

        private void GetPeriods()
        {
            this.Periods = this.PeriodService.GetAll().ToList();
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
            this.PeriodModel = new PeriodModel();
            this.PeriodContext = new EditContext(PeriodModel);
            this.GetPeriods();
            this.IsAdding = false;
        }

        private void SaveAdding()
        {
            if (this.PeriodContext.Validate())
            {
                this.PeriodService.Add(new Period(this.PeriodModel));
                this.PeriodModel = new PeriodModel();
                this.PeriodContext = new EditContext(PeriodModel);
                this.GetPeriods();
                this.IsAdding = false;
            }
        }
    }
}