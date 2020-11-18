using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
    public class Gift
    {

        public string GiftID { get; set; }

        public string GiftName { get; set; }

        public int? GiftPrice { get; set; }

        public int? PieCount { get; set; }

        public int? CakeCount { get; set; }

        public int? CookieCount { get; set; }

        public string GiftImage { get; set; }

        public bool? IsOnSales { get; set; }
    }
}
