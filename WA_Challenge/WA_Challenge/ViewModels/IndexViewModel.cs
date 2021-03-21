using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WA_Challenge.Models;

namespace WA_Challenge.ViewModels
{
    public class IndexViewModel
    {
        public List<SelectListItem> ListaPaises { get; set; }
        public List<SelectListItem> ListaCiudades { get; set; }
        public DatosClimaVista ReporteDelDia { get; set; }
        public List<DatosClimaVista> ListaPronosticos { get; set; }
        public string DescripPais { get; set; }
        public string DescripCiudad { get; set; }
        public string Ident_CiudadSelect { get; set; }
        public int Ident_PaisSelect { get; set; }
        public string MensajeError { get; set; }
    }
}
