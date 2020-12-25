namespace UniAssist.Services
{
    /// <summary>
    /// Theme Service Interface
    /// </summary>
    public interface IConfigService
    {
        
        /// <summary>
        /// Get Working directory path
        /// </summary>
        /// <returns>Path of working directory. Empty if it not set</returns>
        string GetWorkingDirectory();

        /// <summary>
        /// Working directory is exists or not.
        /// </summary>
        /// <returns>True if it is exists.</returns>
        bool WorkingDirectoryExist();

        /// <summary>
        /// Set working directory path.
        /// </summary>
        /// <param name="value">Path of working directory</param>
        void SetWorkingDirectory(string value);
    }
}