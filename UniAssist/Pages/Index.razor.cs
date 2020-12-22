using System;
using System.Linq;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Components;

namespace UniAssist.Pages
{
    /// <summary>
    /// Index Page.
    /// </summary>
    public partial class Index
    {
        /// <summary>
        /// Navigation Manager
        /// </summary>
        [Inject] private NavigationManager NavigationManager { get; set; }
        
        /// <summary>
        /// App is initialized.
        /// </summary>
        private bool IsInitialized { get; set; } = false;
        
        /// <summary>
        /// Working directory path.
        /// </summary>
        private string WorkingDirectoryPath { get; set; }

        /// <summary>
        /// Open application if application is initialized.
        /// </summary>
        private void Open()
        {
            if (this.IsInitialized)
            {
                this.NavigationManager.NavigateTo("/periods");
            }
        }

        /// <summary>
        /// Initialize application if working directory is not empty.
        /// </summary>
        private async void Init()
        {
            if (!this.IsInitialized)
            {
                if (String.IsNullOrEmpty(this.WorkingDirectoryPath))
                {
                    var options = new MessageBoxOptions("You have to add an working directory.");
                    
                    var mainWindow = Electron.WindowManager.BrowserWindows.First();

                    var folder = await Electron.Dialog.ShowMessageBoxAsync(mainWindow, options);
                    return;
                }
                // TODO: Initialize and refresh
            }
        }

        /// <summary>
        /// Choose working directory.
        /// Open open folder dialog.
        /// </summary>
        private async void Choose()
        {
            var options = new OpenDialogOptions
            {
                Title = "Choose Working Directory", 
                Properties = new[]
                {
                    OpenDialogProperty.createDirectory,
                    OpenDialogProperty.openDirectory
                }
            };

            var mainWindow = Electron.WindowManager.BrowserWindows.First();

            var folder = await Electron.Dialog.ShowOpenDialogAsync(mainWindow, options);


            if (folder.Length > 0)
            {
                this.WorkingDirectoryPath = folder[0];
                StateHasChanged();
            }
        }
    }
}