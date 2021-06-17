using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.Email
{
    public interface IEmailSender
    {
        void Send(SendEmailDto dto);
    }
}
