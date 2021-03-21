using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WA_Challenge.Models
{
    public class DatosClima
    {
        public int Id { get; set; }

        public int IdCiudad { get; set; }

        public DateTime Fecha { get; set; }

        public int TemperaturaC { get; set; }

        public int IndicadorClima { get; set; }

        public int Humedad { get; set; }
        public int Precipitaciones { get; set; }
        public int Vientos { get; set; }
    }
}
