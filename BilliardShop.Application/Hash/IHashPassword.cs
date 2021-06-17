using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardShop.Application.Hash
{
    public interface IHashPassword
    {
        string ComputeSha256Hash(string password);
    }
}
