using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trendlog.Models {
    public class User {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public int TotalSale { get; set; }
        public bool IsTotalSalePositiv { get; set; }
        public string Image { get; set; }

    }
}
