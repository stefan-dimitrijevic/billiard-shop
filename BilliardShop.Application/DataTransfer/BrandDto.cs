using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.DataTransfer
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ReadBrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ReadProductDto> Products { get; set; } = new List<ReadProductDto>();
    }
}
