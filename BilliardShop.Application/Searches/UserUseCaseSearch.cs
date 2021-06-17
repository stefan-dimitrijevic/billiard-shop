using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.Searches
{
    public class UserUseCaseSearch : PagedSearch
    {
        public int? UseCaseId { get; set; }
        public int? UserId { get; set; }
    }
}
