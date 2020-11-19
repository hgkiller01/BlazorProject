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
        public List<SelectedItem> Items { get; set; } = new List<SelectedItem>()
            {
                new SelectedItem(){ Text = "天氣狀態" , Value ="Wx",Active = true},
                new SelectedItem(){Text = "下雨機率" , Value = "PoP" },
                new SelectedItem(){Text = "最低氣溫" , Value = "MinT"},
                new SelectedItem(){Text = "最高氣溫" , Value = "MaxT"},
                new SelectedItem(){Text = "體感",Value = "CI"}
            };
        public string SWeatherType { get; set; } = "Wx";
        public string Status { get; set; } = "天氣狀態";
        [Inject]
        public IConfiguration Config { get; set; }
        [Inject]
        public HttpClient Http { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Weathers Souce = await Http.GetFromJsonAsync<Weathers>(Config["ApiUrl"] + "/api/Weather");
            AllData = Souce.records.location;
        }
        protected Weatherelement GetWeatherElement(List<Weatherelement> weathers , string WeatherType)
        {
            return weathers.Where(x => x.elementName == WeatherType).FirstOrDefault();
        }
        public async Task<Task> ChangeDropDown(SelectedItem selectedItem)
        {
            Status = selectedItem.Text;
            Weathers Souce = await Http.GetFromJsonAsync<Weathers>(Config["ApiUrl"] + "/api/Weather");
            AllData = Souce.records.location;
            return Task.CompletedTask;
        }
    }
}
