using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(int id, Type type)
            : base($"Entity of type {type.Name} with an id of {id} already exists.")
        {

        }
    }
}
