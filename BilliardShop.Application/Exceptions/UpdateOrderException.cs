using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.Exceptions
{
    public class UpdateOrderException : Exception
    {
        public UpdateOrderException(string message)
            : base($"{message}")
        {

        }
    }
}
