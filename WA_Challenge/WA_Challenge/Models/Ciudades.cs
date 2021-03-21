using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WA_Challenge.Models
{
    public class Ciudades
    {
        public Ciudades()
        {
            ListaDatosClima = new List<DatosClima>();
        }
        public int Id { get; set; }

        public string NombreCiudad { get; set; }

        public int IdPais { get; set; }

        public List<DatosClima> ListaDatosClima { get; set; }
    }
}
