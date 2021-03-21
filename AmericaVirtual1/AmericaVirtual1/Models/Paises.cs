using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtual1.Models
{
    [Table("Paises")]
    public class Paises
    {
        public Paises()
        {
            ListaCiudades = new List<Ciudades>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre del País es obligatorio")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Nombre del País debe contener 4 y 50 caracteres")]
        public string NombrePais { get; set; }

        public List<Ciudades> ListaCiudades { get; set; }
    }
}
