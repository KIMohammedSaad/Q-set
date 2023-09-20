using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_set1.Models
{
 
    public class ProductSearchViewModel
    {
        public string ProductName { get; set; }
        public string Size { get; set; }
        public decimal? Price { get; set; }
        public DateTime? MfgDate { get; set; }
        public string Category { get; set; }
    }

}
