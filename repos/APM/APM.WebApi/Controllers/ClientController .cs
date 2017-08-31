
using APM.WebApi.Models;
using APM.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using Models = APM.WebAPI.Models;
namespace APM.WebApi.Controllers
{
    [EnableCors("http://localhost:57427", "*", "*")]
    public class ClientsController : ApiController
    {
        // GET: api/Clients
        [EnableQuery()]
        public IQueryable <Client> Get()
        {
            var clientRepository = new ClientRepository();
            return clientRepository.Retrieve().AsQueryable();
        }


        // GET: api/Clients/5
        public Client Get(int id)
        {
            var clientRepository = new ClientRepository();

            var clients = clientRepository.Retrieve();

            var client = clients.FirstOrDefault(p => p.ClientId == id);

            if (client == null)
            {
                client = new Client();
            }

            return client;
        }

        // POST: api/Clients
        public void Post([FromBody]Client client)
        {
            var clientRepository = new ClientRepository();
            var newPrdoduct = clientRepository.Create(client);
        }

        // PUT: api/Clients/5
        public void Put(int id, [FromBody]Client client)
        {
            var clientRepository = new ClientRepository();
            var updateClient = clientRepository.Save(client);
        }

        // DELETE: api/Clients/5
        public void Delete(int id)
        {
            var clientRepository = new ClientRepository();
            var deleteClient = clientRepository.Dalete(id);
        }
    }
}
