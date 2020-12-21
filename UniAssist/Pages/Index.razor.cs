using System;
using System.Linq;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Components;

namespace UniAssist.Pages
{
    public partial class Index
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        private bool IsInitialized { get; set; } = false;
        private string WorkingDirectoryPath { get; set; }

        private void Open()
        {
            if (this.IsInitialized)
            {
                this.NavigationManager.NavigateTo("/periods");
            }
        }

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