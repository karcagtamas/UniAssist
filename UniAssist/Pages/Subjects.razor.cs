using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using UniAssist.Entities;
using UniAssist.Services;

namespace UniAssist.Pages
{
    /// <summary>
    /// Subjects Page
    /// </summary>
    public partial class Subjects
    {
        /// <value>
        /// Period Id
        /// </value>
        [Parameter]
        public string Id { get; set; }

        [Inject] private IPeriodService PeriodService { get; set; }

        [Inject] private ISubjectService SubjectService { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        private Period Period { get; set; } = new();
        private bool IsAdding { get; set; }
        private Subject SubjectModel { get; set; } = new();
        private EditContext SubjectContext { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            this.GetPeriod();
            this.SubjectModel = new Subject(this.Period);
            this.SubjectContext = new EditContext(this.SubjectModel);
        }

        private void GetPeriod()
        {
            this.Period = this.PeriodService.Get(this.Id);
        }

        private void OpenHome()
        {
            this.NavigationManager.NavigateTo("/");
        }

        private void OpenPeriods()
        {
            this.NavigationManager.NavigateTo("/periods");
        }

        private void EditPeriod()
        {
            this.NavigationManager.NavigateTo($"/periods/{this.Id}");
        }

        private void Add()
        {
            this.IsAdding = true;
        }

        private void CancelAdding()
        {
            this.SubjectModel = new Subject(this.Period);
            this.SubjectContext = new EditContext(SubjectModel);
            this.GetPeriod();
            this.IsAdding = false;
        }

        private void SaveAdding()
        {
            if (this.SubjectContext.Validate())
            {
                this.SubjectService.Add(this.SubjectModel);
                this.SubjectModel = new Subject(this.Period);
                this.SubjectContext = new EditContext(SubjectModel);
                this.GetPeriod();
                this.IsAdding = false;
            }
            Console.WriteLine(this.SubjectContext.GetValidationMessages());
        }
    }
}