using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssWebApi.Models
{
    public class Client
    {
        [Key]
        public string cin { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string password { get; set; }
        public string nature_veh { get; set; }
        public string modele_veh { get; set; }
        public string marque_veh { get; set; }

        public virtual ICollection<Alerte> Alertes { get; set; }
    }
}