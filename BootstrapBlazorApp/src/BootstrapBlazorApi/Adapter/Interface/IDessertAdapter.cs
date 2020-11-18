using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootstrapBlazorApi.Adapter.Interface
{
    public interface IDessertAdapter
    {
        IEnumerable<Dessert> GetList();
    }
}
