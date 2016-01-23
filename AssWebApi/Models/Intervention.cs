using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssWebApi.Models
{
    public class Intervention
    {
        [Key, Column(Order = 0)]
        public string idclient { get; set; }
        [Key, Column(Order = 1)]
        public string idremorq { get; set; }
        public string etat { get; set; }

        public virtual Remorqueur Remorqueur {get; set;}
        public virtual Alerte Alerte { get; set; }
    }
}