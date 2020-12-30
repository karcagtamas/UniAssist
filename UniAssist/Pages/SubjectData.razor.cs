using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using UniAssist.Entities;
using UniAssist.Enums;
using UniAssist.Models;
using UniAssist.Services;

namespace UniAssist.Pages
{
    public partial class SubjectData
    {
        /// <value>
        /// Period Id
        /// </value>
        [Parameter]
        public string Id { get; set; }
        
        [Inject] private ISubjectService SubjectService { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        private Subject Subject { get; set; } = new();

        private PageState State { get; set; } = PageState.Content; 
        private SubjectModel SubjectModel { get; set; }
        private EditContext SubjectContext { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            this.GetSubject();
            this.SubjectModel = new SubjectModel(this.Subject);
            this.SubjectContext = new EditContext(this.SubjectModel);
        }

        private void GetSubject()
        {
            this.Subject = this.SubjectService.Get(this.Id);
        }
        
        private void EditSubject()
        {
            this.SetPageState(PageState.Editing);
        }
        
        private void SetPageState(PageState state)
        {
            this.State = state;
        }
        
        private void CancelEditing()
        {
            this.GetSubject();
            this.SubjectModel = new SubjectModel(this.Subject);
            this.SubjectContext = new EditContext(SubjectModel);
            this.SetPageState(PageState.Content);
        }

        private void SaveEditing()
        {
            if (this.SubjectContext.Validate())
            {
                this.UpdateSubjectFromModel();
                this.SubjectService.Update(this.Subject);
                this.GetSubject();
                this.SubjectModel = new SubjectModel(this.Subject);
                this.SubjectContext = new EditContext(SubjectModel);
                this.SetPageState(PageState.Content);
            }
        }
        
        private void OpenHome()
        {
            this.NavigationManager.NavigateTo("/");
        }

        private void OpenSubjects()
        {
            this.NavigationManager.NavigateTo($"/periods/{this.Subject.PeriodId}");
        }

        private void UpdateSubjectFromModel()
        {
            this.Subject.LongName = this.SubjectModel.LongName;
            this.Subject.ShortName = this.SubjectModel.ShortName;
            this.Subject.Code = this.SubjectModel.Code;
            this.Subject.Description = this.SubjectModel.Description;
            this.Subject.Credit = this.SubjectModel.Credit;
            this.Subject.FolderName = this.SubjectModel.FolderName;
            this.Subject.Result = this.SubjectModel.Result;
        }
    }
}