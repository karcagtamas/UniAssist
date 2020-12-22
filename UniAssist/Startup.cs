using Blazored.LocalStorage;
using ElectronNET.API;
using ElectronNET.API.Entities;
using EmbeddedBlazorContent;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniAssist.Services;

namespace UniAssist
{
    /// <summary>
    /// Application Startup class
    /// </summary>
    public class Startup
    {
        
        /// <summary>
        /// Initialize startup
        /// </summary>
        /// <param name="configuration">Startup configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);
            services.AddSingleton<StoreService>();
            services.AddScoped<IThemeService, ThemeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseEmbeddedBlazorContent(typeof(MatBlazor.BaseMatComponent).Assembly);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            
            // Enable Electron
            if (HybridSupport.IsElectronActive)
            {
                ElectronBootstrap(env);
            }
        }

        /// <summary>
        /// Electron bootstrapping.
        /// Add Electron window round web application.
        /// </summary>
        /// <param name="env">Environment</param>
        private async void ElectronBootstrap(IWebHostEnvironment env)
        {
            var browserWindow = await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
            {
                Width = 1152, Height = 940, Show = false, Resizable = false,
                WebPreferences = new WebPreferences {NodeIntegration = true}
            });

            await browserWindow.WebContents.Session.ClearCacheAsync();

            browserWindow.SetMenu(env.IsDevelopment()
                ? new[] {new MenuItem {Role = MenuRole.toggledevtools}}
                : new MenuItem[] { });

            browserWindow.OnReadyToShow += () => browserWindow.Show();
            browserWindow.SetTitle("UniAssist");
        }
    }
}