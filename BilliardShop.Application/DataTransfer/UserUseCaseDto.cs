﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.DataTransfer
{
    public class UserUseCaseDto
    {
        public int Id { get; set; }
        public int UseCaseId { get; set; }
        public int UserId { get; set; }
    }
}
