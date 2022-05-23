using Microsoft.AspNetCore.Mvc;
using RentOfWorkshopAPI.Models;
using RentOfWorkshopsCore.DBContext;
using System.Collections.Generic;
using static RentOfWorkshopAPI.Services.ClientService;
namespace RentOfWorkshopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ClientModel>> GetSpaces() => ClientsList;

        [HttpGet("{id}")]
        public ActionResult<ClientModel> Get(int id)
        {
            var client = GetClient(id);

            if (client == null)
                return NotFound();
            else
                return client;
        }

        [HttpPost]
        public IActionResult Post(Client client)
        {
            Add(client);
            return CreatedAtAction(nameof(Post), new { id = client.Id }, client);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var client = GetClient(id);

            if (client == null)
                return NotFound();
            Delete(id);

            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(int id, Client client)
        {
            if (id != client.Id)
                return BadRequest();

            var currentClient = GetClient(id);
            if (currentClient == null)
                return NotFound();

            Update(id, client);

            return NoContent();
        }
    }
}
