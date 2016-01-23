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

        public virtual ICollection<Alerte> Alertes { get; set; }
    }
}