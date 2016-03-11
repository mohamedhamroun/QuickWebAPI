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
    public class AlerteRemorqueurController : ApiController
    {
        quickContext db = new quickContext();
        // GET api/AlerteRemorqueur
        public IEnumerable<AlerteRemorqueur> Get()
        {
            return db.AlerteRemorqueurs;
        }

        // GET api/AlerteRemorqueur/5
        public List<AlerteRemorqueur> GetAlertesByID(int id)
        {
            return db.AlerteRemorqueurs.Where(a => a.idalerte == id).ToList(); 
        }


        // POST api/AlerteRemorqueur
        public async Task<AlerteRemorqueur> Post(AlerteRemorqueur AlerteRemorqueur)
        {

            if (!ModelState.IsValid)
            {
                return null;
            }

            db.AlerteRemorqueurs.Add(AlerteRemorqueur);
            await db.SaveChangesAsync();

            return AlerteRemorqueur;
        }

        // PUT api/AlerteRemorqueur/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/AlerteRemorqueur/5
        public void Delete(int id)
        {
        }
    }
}
