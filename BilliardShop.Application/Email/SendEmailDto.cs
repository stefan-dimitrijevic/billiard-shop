﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.Email
{
    public class SendEmailDto
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
