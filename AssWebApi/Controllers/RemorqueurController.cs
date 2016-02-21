using AssWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AssWebApi.Controllers
{
     [EnableCors("*", "*", "*")]
    public class RemorqueurController : ApiController
    {
        quickContext db = new quickContext();
        // GET api/Remorqueur
        public IEnumerable<Remorqueur> Get()
        {
         
            return db.Remorqueurs;
        }


        // GET api/Remorqueur/5
        [Route("api/Remorqueur/ByMatricule/{matricule}")]
        public async Task<Remorqueur> Get(string matricule)
        {
            return await db.Remorqueurs.FindAsync(matricule);
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


        [Route("api/Remorqueur/Interventions/{matricule}/{etat}")]
        public async Task<List<Alerte>> GetRemorInterventions(string matricule,string etat)
        {
            if(etat.Equals("All"))
            {
                Remorqueur remorq = await db.Remorqueurs.Where(c => c.matricule.Equals(matricule)).Include(c => c.Alertes).FirstOrDefaultAsync();

                return remorq.Alertes.ToList();
            }
            else
            {
                Remorqueur remorq = await db.Remorqueurs.Where(c => c.matricule.Equals(matricule)).Include(c => c.Alertes).FirstOrDefaultAsync();

                return remorq.Alertes.Where(a=>a.etat.Equals("Recherche Termine")).ToList();
            }           
           
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

        /*Call GetAllNearestFamousPlaces() method to get list of nearby places depending 
    upon user current location.
    Note: GetAllNearestFamousPlaces() method takes 2 parameters as input
   that is GetAllNearestFamousPlaces(user_current_Latitude,user_current_Longitude) */

         [Route("api/Remorqueur/Nearest/{id}")]
        public List<Remorqueur> GetAllNearestFamousPlaces(int id)
        {

            Alerte alerte = db.Alertes.Find(id);
            var distanceInMiles = 0.5;
            var distanceInMeters = distanceInMiles * 1609.344;
            DbGeography searchLocation = DbGeography.PointFromText(string.Format("POINT({0} {1})", -45, 45), 4326);

     var nearbyLocations = 
    (from location in db.Remorqueurs
     where DbGeography.PointFromText("POINT(" + location.longitude + " " + location.latitude + ")",4326).Distance(searchLocation) < distanceInMeters
     select new 
     {
         location
     })
    .ToList();

            return new List<Remorqueur>();
        }

        private double Distance(double lat1, double lon1, double lat2, double lon2)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = (dist * 60 * 1.1515) / 0.6213711922;          //miles to kms
            return (dist);
        }

        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private double rad2deg(double rad)
        {
            return (rad * 180.0 / Math.PI);
        }
  
    }
}
