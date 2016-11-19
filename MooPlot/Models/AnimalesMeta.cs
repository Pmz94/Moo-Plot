using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MooPlot.Models
{
    public class AnimalesMeta
    {
        [Display(Name = "Numero de caravana")]
        public int Num_Caravana { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public string Genero { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        public System.DateTime Fecha_Nac { get; set; }
        [Display(Name = "Peso de nacimiento")]
        public float Peso_Nac { get; set; }
        [Display(Name = "IMC Actual")]
        public float IMC_Actual { get; set; }
        public string Observaciones { get; set; }
        [Display(Name = "Código de Siniga")]
        public int Cod_Signia { get; set; }
        [Display(Name = "Está muerto")]
        public string Status { get; set; }
        [Display(Name = "Fecha de muerte")]
        public Nullable<System.DateTime> Fecha_Muerte { get; set; }
        [Display(Name = "Ruta de imagen")]
        public string Imagen__Ruta_ { get; set; }
        [Display(Name = "Imagen")]
        public byte[] Imagen__Foto_ { get; set; }
        [Display(Name = "Peso actual")]
        public float Peso_Actual { get; set; }
        public Nullable<System.DateTime> Celo { get; set; }
    }
}