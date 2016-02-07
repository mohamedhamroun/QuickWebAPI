using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssWebApi.Models
{
    public class Alerte
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string cin { get; set; }
        public string date { get; set; }
        public string message { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }

        public  Client Client { get; set; }
    }
}