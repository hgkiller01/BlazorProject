using DataLibrary.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using BootstrapBlazor.Components;

namespace BootstrapBlazorApp1.Server.Pages
{
    public partial class WeatherPage
    {
        public List<Location> AllData { get; set; }
        [Inject]
        public IConfiguration Config { get; set; }
        [Inject]
        public HttpClient Http { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Weathers Souce = await Http.GetFromJsonAsync<Weathers>(Config["ApiUrl"] + "/api/Weather");
            AllData = Souce.records.location;
        }

    }
}
