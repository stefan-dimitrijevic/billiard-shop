using BilliardShop.Application.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public void Send(SendEmailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("stefandimitrijevicaspict@gmail.com", "stefanaspict")
            };

            var message = new MailMessage("stefandimitrijevicaspict@gmail.com", dto.SendTo);
            message.Subject = dto.Subject;
            message.Body = dto.Body;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
