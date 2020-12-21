using Blazored.LocalStorage;
using ElectronNET.API;
using ElectronNET.API.Entities;
using EmbeddedBlazorContent;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UniAssist.Data;
using UniAssist.Services;

namespace UniAssist
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
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

            if (HybridSupport.IsElectronActive)
            {
                ElectronBootstrap(env);
            }
        }

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