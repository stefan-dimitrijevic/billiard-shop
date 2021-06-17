using BilliardShop.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilliardShop.Api.Core
{
    public class AnonymousActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Anonymous";

        public IEnumerable<int> AllowedUseCases => new List<int> { 2, 3, 7, 8, 12, 13, 16 };
    }
}
