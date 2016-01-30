using AssWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AssWebApi.Controllers
{
    public class ClientController : ApiController
    {
        quickContext db = new quickContext();
        // GET api/client
        public IEnumerable<Client> Get()
        {
            return db.Clients;
        }

        // GET api/client/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/client/Login")]
        public bool PostClientLogi(Client client)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }


            return db.Clients.Where(c => c.cin.Equals(client.cin) && c.password.Equals(client.password)).Count() >0;
        }

        // POST api/client
        public async Task<Client> Post(Client client)
        {
           
            if (!ModelState.IsValid)
            {
                return null;
            }
            

            db.Clients.Add(client);
            await db.SaveChangesAsync();

            return client;
        }

        // PUT api/client/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/client/5
        public void Delete(int id)
        {
        }
    }
}
