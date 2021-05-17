using UniAssist.Entities;
using UniAssist.Models;

namespace UniAssist.Services
{
    /// <summary>
    /// Period Service Interface
    /// </summary>
    public interface IPeriodService : IDatabaseService<Period>
    {
        /// <summary>
        /// Create folder for Period
        /// <param name="period">Period</param>
        /// </summary>
        void CreatePeriodFolder(Period period);

        /// <summary>
        /// Update period folder's name to new name
        /// </summary>
        /// <param name="period">Period</param>
        /// <param name="oldName">Old folder name</param>
        void UpdatePeriodFolderName(Period period, string oldName);

        /// <summary>
        /// Delete period folder
        /// </summary>
        /// <param name="period">Period object</param>
        void DeletePeriodFolder(Period period);

        /// <summary>
        /// Sync Periods and check with folders
        /// </summary>
        /// <returns>Sync result</returns>
        PeriodSyncResult Sync();
    }
}