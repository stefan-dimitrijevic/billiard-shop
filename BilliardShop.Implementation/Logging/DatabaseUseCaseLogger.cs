using BilliardShop.Application;
using BilliardShop.Domain;
using BilliardShop.EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly BilliardShopContext _context;

        public DatabaseUseCaseLogger(BilliardShopContext context)
        {
            _context = context;
        }
        public void Log(IUseCase useCase, IApplicationActor actor, object data)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                Data = JsonConvert.SerializeObject(data),
                Actor = actor.Identity
            });

            _context.SaveChanges();
        }
    }
}
