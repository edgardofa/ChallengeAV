using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtual1.Models
{
    [Table("Ciudades")]
    public class Ciudades
    {
        public Ciudades()
        {
            ListaDatosClima = new List<DatosClima>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre de la Ciudad es obligatorio")]
        [StringLength(75, MinimumLength = 4, ErrorMessage = "Nombre del Nombre de la Ciudad debe contener 4 y 75 caracteres")]
        public string NombreCiudad { get; set; }

        [Required]
        public int IdPais { get; set; }

        public List<DatosClima> ListaDatosClima { get; set; }
    }
}
