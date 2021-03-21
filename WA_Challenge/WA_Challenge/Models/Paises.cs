using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WA_Challenge.Models
{
    public class Paises
    {
        public Paises()
        {
            ListaCiudades = new List<Ciudades>();
        }
        public int Id { get; set; }

        public string NombrePais { get; set; }

        public List<Ciudades> ListaCiudades { get; set; }
    }
}
