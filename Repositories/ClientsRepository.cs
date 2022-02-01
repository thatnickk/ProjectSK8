using Microsoft.EntityFrameworkCore;
using ProiectSK8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly Context db;

        public ClientsRepository(Context context)
        {
            this.db = context;
        }

        public IQueryable<Client> GetClients()
        {
            var clients = db.Clients;
            return clients; 
        }

        public IQueryable<string> GetClientsIds()
        {
            var clientsIds = db.Clients.Select(x => x.Id);

            return clientsIds;
        }

        public IQueryable<Client> GetClientsJoin()
        {
            var clients = db.Clients
                .Include(x => x.Orders);
            return clients;
        }

        public async Task Create(Client client)
        {
            await db.Clients.AddAsync(client);
            await db.SaveChangesAsync();
        }

        public async Task Update(Client client)
        {
            db.Clients.Update(client);
            await db.SaveChangesAsync();
        }
        public async Task Delete(Client client)
        {
            db.Clients.Remove(client);
            await db.SaveChangesAsync();
        }
    }
}
