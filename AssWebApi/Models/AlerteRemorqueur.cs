using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssWebApi.Models
{
      public class AlerteRemorqueur
      {
        public int Id { get; set; }
        public int idalerte { get; set; } 
        public string idremorq { get; set; }

        public virtual Remorqueur Remorqueur {get; set;}
        public  Alerte Alerte { get; set; }
     }
}