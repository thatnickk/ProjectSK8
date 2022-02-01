using ProiectSK8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Managers
{
    public interface ITokenManager
    {
        Task<string> GenerateToken(User user);
    }
}
