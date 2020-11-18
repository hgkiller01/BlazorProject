using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
    public class Orders
    {
        public string OrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? Orderstat { get; set; }

        public string DeliveryAddress { get; set; }
        public string Account { get; set; }
    }
}
