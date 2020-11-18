using BootstrapBlazorApp.WebAssembly.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using BootstrapBlazorApp.WebAssembly.Setting;

namespace BootstrapBlazorApp.WebAssembly
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            HttpClient http = new HttpClient();
            builder.Services.AddSingleton(http.GetFromJsonAsync<Settings>("settings.json"));

            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // 增加 BootstrapBlazor 组件
            builder.Services.AddBootstrapBlazor();

            builder.Services.AddSingleton<WeatherForecastService>();

            var host = builder.Build();

            await host.RunAsync();
        }
    }
}
