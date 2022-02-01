using ProiectSK8.Entities;
using ProiectSK8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Managers
{
    public interface IClientsManager
    {
        List<Client> GetClients();
        List<string> GetClientsIds();
        List<Client> GetClientsJoin();
        List<ClientIdAndOrder> GetClientsFiltered();
        Client GetClientById(string id);
        Task Create(Client client);
        Task Update(ClientModel client);
        Task Delete(string id);
    }
}
