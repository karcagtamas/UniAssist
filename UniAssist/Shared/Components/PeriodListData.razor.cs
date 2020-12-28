using Microsoft.AspNetCore.Components;
using UniAssist.Entities;

namespace UniAssist.Shared.Components
{
    /// <summary>
    /// Period List Data Component
    /// </summary>
    public partial class PeriodListData
    {
        /// <value>
        /// Period
        /// </value>
        [Parameter]
        public Period Period { get; set; }
        
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
            if (this.Period.Notes != null && this.Period.Notes.Count > 0)
            {
                msg += "Notes: " + this.Period.Notes.Count;
            }
            
            if (this.Period.Tasks != null && this.Period.Tasks.Count > 0)
            {
                if (msg != "")
                {
                    msg += " ";
                }

                msg += "Tasks: " + this.Period.Tasks.Count;
            }
            
            if (this.Period.Subjects != null && this.Period.Subjects.Count > 0)
            {
                if (msg != "")
                {
                    msg += " ";
                }

                msg += "Subjects: " + this.Period.Subjects.Count;
            }
            return msg == "" ? this.Period.Name : msg;
        }
    }
}