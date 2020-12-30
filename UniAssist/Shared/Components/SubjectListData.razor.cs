using Microsoft.AspNetCore.Components;
using UniAssist.Entities;

namespace UniAssist.Shared.Components
{
    /// <summary>
    /// Subject list Data Component
    /// </summary>
    public partial class SubjectListData
    {
        /// <value>
        /// Period
        /// </value>
        [Parameter]
        public Subject Subject { get; set; }
        
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        
        /// <value>
        /// Put start divider
        /// </value>
        [Parameter]
        public bool StartDivider { get; set; }
        
        /// <value>
        /// Put end divider
        /// </value>
        [Parameter]
        public bool EndDivider { get; set; }

        private string GetTooltipMessage()
        {
            string msg = "";
            if (this.Subject.Notes != null && this.Subject.Notes.Count > 0)
            {
                msg += "Notes: " + this.Subject.Notes.Count;
            }
            
            if (this.Subject.Tasks != null && this.Subject.Tasks.Count > 0)
            {
                if (msg != "")
                {
                    msg += " ";
                }

                msg += "Tasks: " + this.Subject.Tasks.Count;
            }

            return msg == "" ? this.Subject.LongName : msg;
        }

        private void Open()
        {
            this.NavigationManager.NavigateTo($"/subjects/{this.Subject.Id}");
        }
    }
}