using BilliardShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.DataTransfer
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public IEnumerable<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>();
    }
    public class ReadOrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public string UserInfo { get; set; }
        public string StatusName { get; set; }
        public IEnumerable<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>();
        public decimal TotalPrice { get; set; }
    }

    public class ChangeOrderStatusDto
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
