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
    public class RemorqueurController : ApiController
    {
        quickContext db = new quickContext();
        // GET api/client
        public IEnumerable<Remorqueur> Get()
        {
            return db.Remorqueurs;
        }

        // GET api/client/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/client
        public async Task<Remorqueur> Post(Remorqueur client)
        {
           
            if (!ModelState.IsValid)
            {
                return null;
            }


            db.Remorqueurs.Add(client);
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
