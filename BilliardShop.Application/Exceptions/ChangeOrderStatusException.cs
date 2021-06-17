using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.Exceptions
{
    public class ChangeOrderStatusException : Exception
    {
        public ChangeOrderStatusException(string message)
            : base($"Status change is not allowed. {message}")
        {

        }
    }
}
