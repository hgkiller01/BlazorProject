using BootstrapBlazorApi.Adapter.Interface;
using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapBlazorApi.Adapter
{
    public class GiftAdapter : DataBase, IGiftAdapter
    {
        public IEnumerable<Gift> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
