using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.DataTransfer
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ReadCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ReadProductDto> Products { get; set; } = new List<ReadProductDto>();
    }
}
