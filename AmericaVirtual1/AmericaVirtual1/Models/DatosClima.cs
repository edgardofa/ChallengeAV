using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmericaVirtual1.Models
{
    [Table("DatosClima")]
    public class DatosClima
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdCiudad { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int TemperaturaC { get; set; }

        [Required]
        public int IndicadorClima { get; set; }

        public int Humedad { get; set; }
        public int Precipitaciones { get; set; }
        public int Vientos { get; set; }

    }
}
