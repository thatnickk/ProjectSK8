using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectSK8.Entities;
using ProiectSK8.Managers;
using ProiectSK8.Models;
using ProiectSK8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectSK8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientsManager manager;

        public ClientController(IClientsManager clientsManager)
        {
            this.manager = clientsManager;
        }
        
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetClients()
        {
            var clients = manager.GetClients();

            return Ok(clients);
        }
        [HttpGet("ids")]
        public async Task<IActionResult> GetClientsIds()
        {
            var clientsIds = manager.GetClientsIds();

            return Ok(clientsIds);
        }
        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var client = manager.GetClientById(id);

            return Ok(client);
        }

        [HttpGet("join")]
        public async Task<IActionResult> GetClientsJoin()
        {
            var clientsJoin = manager.GetClientsJoin();
            return Ok(clientsJoin);
        }
        [HttpGet("filter")]

        public async Task<IActionResult> GetClientsFiltered()
        {
            var clientsFiltered = manager.GetClientsFiltered();
            return Ok(clientsFiltered);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] ClientModel client)
        {
            var newClient = new Client
            {
                Id = client.Id,
                Nume = client.Nume,
                Telefon = client.Telefon
            };

            await manager.Create(newClient);
            return Ok();
        }

        [HttpPut]

        public async Task<IActionResult> Update([FromBody] ClientModel client)
        {
            await manager.Update(client);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] string client)
        {
            await manager.Delete(client);
            return Ok();
        }
    }
}
