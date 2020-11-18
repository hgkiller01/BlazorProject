using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Model;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Net.Http;
using BootstrapBlazorApp.WebAssembly.Setting;

namespace BootstrapBlazorApp.WebAssembly.Pages
{
    public partial class Weather : ComponentBase
    {
        public Weather weather { get; set; }
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public Settings settings { get; set; }
        protected override async Task OnInitializedAsync()
        {
            HttpClient client = new HttpClient();
            weather = await client.GetFromJsonAsync<Weather>(settings.ApiUrl + "/api/Weather");
        }
    }
}
