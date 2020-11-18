using DataLibrary.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text;
using Newtonsoft.Json;

namespace DataLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private IConfiguration _config;
        public WeatherController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<Weathers> Get([FromQuery]List<string> LocationName)
        {            
            string Query = _config["Appsettings:WeatherUrl"] + "?Authorization=" + _config["Appsettings:Token"];
            if(LocationName.Count > 0)
            {
                string Location = string.Join(",", LocationName);
                Query += "&locationName=" + Location;
            }
            HttpClient http = new HttpClient();
            var response = await http.GetAsync(Query);
            //如果 httpstatus code 不是 200 時會直接丟出 expection
            var buffer = await response.Content.ReadAsByteArrayAsync();
            var byteArray = buffer.ToArray();
            var responseString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            var ext = JsonConvert.DeserializeObject<Weathers>(responseString);
            return ext;
        }
    }
}
