using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using DataLibrary.Model;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace BootstrapBlazorApp1.Server.Pages
{
    public partial class DessertPage
    {
        public List<Dessert> desserts { get; set; }
        [Inject]
        public HttpClient Http { get; set; }
        [Inject]
        public IConfiguration Config { get; set; }
        public IEnumerable<int> PageSize => new int[] { 10, 15, 20 };
        public int TotalCount { get; set; }

        protected override async Task OnInitializedAsync()
        {
            desserts = await Http.GetFromJsonAsync<List<Dessert>>(Config["ApiUrl"] + "/api/Dessert/GetDessert?pageIndex=1&pageSize=10");
            TotalCount = await Http.GetFromJsonAsync<int>(Config["ApiUrl"] + "/api/Dessert/GetCount");
        }
        protected Task<QueryData<Dessert>> OnQueryAsync(QueryPageOptions options)
        {
            return BindItems(desserts, options);

        }
        protected async Task<QueryData<Dessert>> BindItems(List<Dessert> dessertes, QueryPageOptions options)
        {
            dessertes = await Http.GetFromJsonAsync<List<Dessert>>(Config["ApiUrl"] + "/api/Dessert/GetDessert?pageIndex="
                + options.PageIndex +"&pageSize="+options.PageItems);
            //return Task.FromResult(new QueryData<Dessert>()
            //{
            //    Items = dessertes,
            //    TotalCount = TotalCount,
            //    IsSorted = true,
            //    IsFiltered = false,
            //    IsSearch = false
            //});
            return new QueryData<Dessert>()
            {
                Items = dessertes,
                TotalCount = TotalCount
            };
        }
    }
}
