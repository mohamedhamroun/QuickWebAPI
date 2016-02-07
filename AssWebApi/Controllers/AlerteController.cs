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
    public class AlerteController : ApiController
    {
        quickContext db = new quickContext();
        // GET api/Alerte
        public IEnumerable<Alerte> Get()
        {
            return db.Alertes.Include(a=>a.Client);
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
        public Alerte Put(int id, Alerte Alerte)
        {
            if (!ModelState.IsValid)
            {
                new Alerte();
            }

            if (id != Alerte.Id)
            {
                new Alerte();
            }

            db.Entry(Alerte).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return Alerte;
        }

        // DELETE api/Alerte/5
        public bool Delete(int id)
        {
            Alerte Alerte = db.Alertes.Find(id);
            if (Alerte == null)
            {
                return false;
            }

            db.Alertes.Remove(Alerte);
            db.SaveChanges();

            return true;
        }
    }
}
