using BilliardShop.Application.DataTransfer;
using BilliardShop.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.Queries
{
    public interface IReadProductsQuery : IQuery<ProductSearch, PagedResponse<ReadProductDto>>
    {
    }
}
