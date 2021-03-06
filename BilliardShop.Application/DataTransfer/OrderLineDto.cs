using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.DataTransfer
{
    public class OrderLineDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int? ProductId { get; set; }

        public decimal Price { get; set; }
    }
}
