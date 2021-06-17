using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Domain
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();

    }
    public enum OrderStatus
    {
        Recieved,
        Delivered,
        Shipped,
        Canceled
    }
}
