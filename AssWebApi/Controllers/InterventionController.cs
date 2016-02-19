//using AssWebApi.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;

//namespace AssWebApi.Controllers
//{
//    public class InterventionController : ApiController
//    {
//        quickContext db = new quickContext();
//        // GET api/Intervention
//        public IEnumerable<Intervention> Get()
//        {
//            return db.Interventions;
//        }

//        // GET api/Intervention/5
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/Intervention
//        public async Task<Intervention> Post(Intervention Intervention)
//        {
           
//            if (!ModelState.IsValid)
//            {
//                return null;
//            }
            

//            db.Interventions.Add(Intervention);
//            await db.SaveChangesAsync();

//            return Intervention;
//        }

//        // PUT api/Intervention/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/Intervention/5
//        public void Delete(int id)
//        {
//        }
//    }
//}
