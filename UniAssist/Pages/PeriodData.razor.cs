using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using UniAssist.Entities;
using UniAssist.Enums;
using UniAssist.Models;
using UniAssist.Services;

namespace UniAssist.Pages
{
    /// <summary>
    /// Subjects Page
    /// </summary>
    public partial class PeriodData
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

        private PageState State { get; set; } = PageState.Content; 
        private SubjectModel SubjectModel { get; set; } = new();
        private EditContext SubjectContext { get; set; }
        private PeriodModel PeriodModel { get; set; }
        private EditContext PeriodContext { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            this.GetPeriod();
            this.SubjectModel = new SubjectModel();
            this.SubjectContext = new EditContext(this.SubjectModel);
            this.PeriodModel = new PeriodModel(this.Period);
            this.PeriodContext = new EditContext(this.PeriodModel);
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
            this.SetPageState(PageState.Editing);
        }

        private void Add()
        {
            this.SetPageState(PageState.Adding);
        }

        private void CancelAdding()
        {
            this.SubjectModel = new SubjectModel();
            this.SubjectContext = new EditContext(SubjectModel);
            this.GetPeriod();
            this.SetPageState(PageState.Content);
        }

        private void SaveAdding()
        {
            if (this.SubjectContext.Validate())
            {
                this.SubjectService.Add(new Subject(this.Period, this.SubjectModel));
                this.SubjectModel = new SubjectModel();
                this.SubjectContext = new EditContext(SubjectModel);
                this.GetPeriod();
                this.SetPageState(PageState.Content);
            }
        }

        private void SetPageState(PageState state)
        {
            this.State = state;
        }
        
        private void CancelEditing()
        {
            this.GetPeriod();
            this.PeriodModel = new PeriodModel(this.Period);
            this.PeriodContext = new EditContext(PeriodModel);
            this.SetPageState(PageState.Content);
        }

        private void SaveEditing()
        {
            if (this.PeriodContext.Validate())
            {
                this.UpdatePeriodFromModel();
                this.PeriodService.Update(this.Period);
                this.GetPeriod();
                this.PeriodModel = new PeriodModel(this.Period);
                this.PeriodContext = new EditContext(PeriodModel);
                this.SetPageState(PageState.Content);
            }
        }

        private void UpdatePeriodFromModel()
        {
            this.Period.Name = this.PeriodModel.Name;
            this.Period.FolderName = this.PeriodModel.FolderName;
        }
    }
}