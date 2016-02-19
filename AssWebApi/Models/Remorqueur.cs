using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssWebApi.Models
{
    public class Remorqueur
    {
        
        [Key]
        public string matricule { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string password { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }

        public virtual ICollection<Alerte> Alertes { get; set; }
    }
}