using BilliardShop.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.Commands
{
    public interface ICreateProductCommand : ICommand<ProductDto>
    {
    }
}
