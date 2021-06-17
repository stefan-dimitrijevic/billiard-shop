using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.Searches
{
    public class ProductSearch : PagedSearch
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int? BrandId { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
    }
}
