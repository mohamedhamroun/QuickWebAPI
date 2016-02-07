using AssWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

         [Route("api/client/ByCin/{cin}")]
        public async Task<Client> Get(string cin)
        {
            return await db.Clients.FindAsync(cin);
        }

        [Route("api/client/Alertes/{cin}")]
        public async Task<List<Alerte>> GetClientAlertes(string cin)
        {
            Client client= await db.Clients.Where(c => cin.Equals(c.cin)).Include(c => c.Alertes).FirstOrDefaultAsync();
            return client.Alertes.ToList();
        }



        [Route("api/client/Login")]
        public bool PostClientLogin(Client client)
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

       [Route("api/client/Update/{cin}")]
        public Client PutClient(string cin, Client Client)
        {
            if (!ModelState.IsValid)
            {
                new Client();
            }

            if (cin != Client.cin)
            {
                new Client();
            }

            db.Entry(Client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return Client;
        }

        // DELETE api/client/5
        public void Delete(int id)
        {
        }

         [Route("api/client/Remove/{cin}")]
        public bool DeleteClient (string cin)
        {
            Client client = db.Clients.Find(cin);
            if (client == null)
            {
                return false;
            }
           

            db.Clients.Remove(client);
            db.SaveChanges();

            return true;
        }
    }
}
