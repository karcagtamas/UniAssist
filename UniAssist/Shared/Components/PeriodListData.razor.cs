using Microsoft.AspNetCore.Components;
using UniAssist.Entities;

namespace UniAssist.Shared.Components
{
    /// <summary>
    /// Period List Data Component
    /// </summary>
    public partial class PeriodListData
    {
        /// <summary>
        /// Period
        /// </summary>
        [Parameter]
        public Period Period { get; set; }
    }
}