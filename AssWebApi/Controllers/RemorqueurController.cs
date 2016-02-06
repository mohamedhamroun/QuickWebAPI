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
    public class RemorqueurController : ApiController
    {
        quickContext db = new quickContext();
        // GET api/Remorqueur
        public IEnumerable<Remorqueur> Get()
        {
            return db.Remorqueurs;
        }

        // GET api/Remorqueur/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/Remorqueur/Login")]
        public bool PostRemorqueurLogi(Remorqueur Remorqueur)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }


            return db.Remorqueurs.Where(c => c.matricule.Equals(Remorqueur.matricule) && c.password.Equals(Remorqueur.password)).Count() > 0;
        }

        // POST api/Remorqueur
        public async Task<Remorqueur> Post(Remorqueur Remorqueur)
        {
           
            if (!ModelState.IsValid)
            {
                return null;
            }


            db.Remorqueurs.Add(Remorqueur);
            await db.SaveChangesAsync();

            return Remorqueur;
        }

        // PUT api/Remorqueur/5
        [Route("api/Remorqueur/Update/{matricule}")]
        public Remorqueur PutRemorqueur(string matricule, Remorqueur Remorqueur)
        {
            if (!ModelState.IsValid)
            {
                new Remorqueur();
            }

            if (matricule != Remorqueur.matricule)
            {
                new Remorqueur();
            }

            db.Entry(Remorqueur).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Remorqueur;
        }

        // DELETE api/Remorqueur/5
        public void Delete(int id)
        {
        }

        [Route("api/Remorqueur/Remove/{matricule}")]
        public bool DeleteRemorqueur(string matricule)
        {
            Remorqueur Remorqueur = db.Remorqueurs.Find(matricule);
            if (Remorqueur == null)
            {
                return false;
            }


            db.Remorqueurs.Remove(Remorqueur);
            db.SaveChanges();

            return true;
        }
    }
}
