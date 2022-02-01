using ProiectSK8.Entities;
using ProiectSK8.Models;
using ProiectSK8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Managers
{
    public class ClientsManager : IClientsManager
    {
        private IClientsRepository repo;

        public ClientsManager(IClientsRepository clientsRepository)
        {
            this.repo = clientsRepository;
        }

        public async Task Create(Client client)
        {
            await repo.Create(client);
        }

        public async Task Update(ClientModel clientul)
        {
            var client = repo.GetClients().FirstOrDefault(x => x.Id == clientul.Id);
            client.Nume = clientul.Nume;
            client.Telefon = clientul.Telefon;
            await repo.Update(client);

        }

        public Client GetClientById(string id)
        {
            var client = repo.GetClients().FirstOrDefault(x => x.Id == id);
            return client;
        }

        public async Task Delete(string id)
        {
            var client = GetClientById(id);
            await repo.Delete(client);
        }

        public List<Client> GetClients()
        {
            return repo.GetClients().ToList();
        }
        public List<string> GetClientsIds()
        {
            return repo.GetClientsIds().ToList();
        }
        public List<Client> GetClientsJoin()
        {
            return repo.GetClientsJoin().ToList();
        }

        public List<ClientIdAndOrder> GetClientsFiltered()
        {
            var clients = repo.GetClientsJoin();
            var clientsFiltered = clients.Where(x => x.Orders.Count > 0)
                .Select(x => new ClientIdAndOrder{ Id = x.Id, FirstOrder = x.Orders.FirstOrDefault().Id })
                .ToList();
            return clientsFiltered;
        }
    }
}
