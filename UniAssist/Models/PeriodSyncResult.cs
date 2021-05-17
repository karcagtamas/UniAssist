using System.Collections.Generic;

namespace UniAssist.Models
{
    /// <summary>
    /// Period File Sync result
    /// </summary>
    public class PeriodSyncResult
    {
        /// <summary>
        /// Un Created folder paths
        /// </summary>
        public List<string> UnCreated { get; set; }
        
        /// <summary>
        /// Un Saved folder paths
        /// </summary>
        public List<string> UnSaved { get; set; }

        /// <summary>
        /// Initialize Periods on File System
        /// </summary>
        public PeriodSyncResult()
        {
            UnCreated = new List<string>();
            UnSaved = new List<string>();
        }
    }
}