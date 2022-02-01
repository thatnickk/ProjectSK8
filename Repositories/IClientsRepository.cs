using ProiectSK8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Repositories
{
    public interface IClientsRepository
    {
        IQueryable<Client> GetClients();
        IQueryable<string> GetClientsIds();
        IQueryable<Client> GetClientsJoin();
        Task Create(Client client);
        Task Update(Client client);
        Task Delete(Client client);
    }
}
