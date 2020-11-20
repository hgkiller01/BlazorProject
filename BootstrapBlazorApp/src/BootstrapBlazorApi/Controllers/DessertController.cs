using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazorApi.Adapter.Interface;
using DataLibrary.Model;

namespace BootstrapBlazorApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DessertController : ControllerBase
    {
        private IDessertAdapter Adapter;
        public DessertController(IDessertAdapter dessertAdapter)
        {
            Adapter = dessertAdapter;
        }
        [HttpGet]
        public int GetCount()
        {
            return Adapter.GetTotalCount();
        }
        [HttpGet]
        public IEnumerable<Dessert> GetDessert(int pageIndex,int pageSize)
        {
            var data = Adapter.GetList(pageIndex,pageSize);
            return data;
        }
    }
}
