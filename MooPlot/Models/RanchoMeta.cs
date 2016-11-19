using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MooPlot.Models
{
    public class RanchoMeta
    {
        public int ID_Rancho { get; set; }
        [Display(Name = "Nombre del rancho")]
        public string Nombre_Rancho { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public int Hectareas { get; set; }
        public string Dueño { get; set; }
    }
}