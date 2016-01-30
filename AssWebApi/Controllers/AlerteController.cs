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
    public class AlerteController : ApiController
    {
        quickContext db = new quickContext();
        // GET api/Alerte
        public IEnumerable<Alerte> Get()
        {
            return db.Alertes;
        }

        // GET api/Alerte/5
        public string Get(int id)
        {
            return "value";
        }

      
        // POST api/Alerte
        public async Task<Alerte> Post(Alerte Alerte)
        {
           
            if (!ModelState.IsValid)
            {
                return null;
            }
            

            db.Alertes.Add(Alerte);
            await db.SaveChangesAsync();

            return Alerte;
        }

        // PUT api/Alerte/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Alerte/5
        public void Delete(int id)
        {
        }
    }
}
