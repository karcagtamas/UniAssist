using System;
using System.Linq;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Components;
using UniAssist.Services;

namespace UniAssist.Pages
{
    /// <summary>
    /// Index Page.
    /// </summary>
    public partial class Index
    {
        /// <value>
        /// Navigation Manager
        /// </value>
        [Inject] private NavigationManager NavigationManager { get; set; }
        
        /// <value>
        /// Config Service
        /// </value>
        [Inject]
        private IConfigService ConfigService { get; set; }
        
        /// <value>
        /// App is initialized.
        /// </value>
        private bool IsInitialized { get; set; } = false;
        
        /// <value>
        /// Working directory path.
        /// </value>
        private string WorkingDirectoryPath { get; set; }

        /// <summary>
        /// Initialize Index Component
        /// </summary>
        protected override void OnInitialized()
        {
            this.IsInitialized = this.ConfigService.WorkingDirectoryExist();
        }

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

                    await Electron.Dialog.ShowMessageBoxAsync(mainWindow, options);
                    return;
                }
                
                this.ConfigService.SetWorkingDirectory(this.WorkingDirectoryPath);
                this.IsInitialized = this.ConfigService.WorkingDirectoryExist();
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