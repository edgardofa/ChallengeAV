using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WA_Challenge.Models
{
    public class DatosClimaVista:DatosClima
    {
        public string NombreDelDia { get; set; }
        public decimal TemperaturaF { get; set; }
        public string DescripClima { get; set; }
        public string UrlImagen { get; set; }
        //---- Constructores ------------------
        public DatosClimaVista(){}
        public DatosClimaVista(DatosClima datosClima)
        {

            this.DescripClima = CompletarDescripClima(datosClima.IndicadorClima - 1);
            this.Fecha = datosClima.Fecha;
            this.Humedad = datosClima.Humedad;
            this.Id = datosClima.Id;
            this.IdCiudad = datosClima.IdCiudad;
            this.IndicadorClima = datosClima.IndicadorClima;
            //int diaSemana = (int)datosClima.Fecha.DayOfWeek;
            string weekdayName = datosClima.Fecha.ToString("dddd",
                                       new CultureInfo("es-ES"));
            this.NombreDelDia = weekdayName.ToUpper();
            this.Precipitaciones = datosClima.Precipitaciones;
            this.TemperaturaC = datosClima.TemperaturaC;

            decimal calcTemp_Farenheid =(decimal) (datosClima.TemperaturaC * 1.8) + 32;
            calcTemp_Farenheid = decimal.Round(calcTemp_Farenheid, 2);
            this.TemperaturaF = calcTemp_Farenheid;
            this.UrlImagen = "/Imagenes/pngkite-" + datosClima.IndicadorClima.ToString() + ".png"; 
            this.Vientos = datosClima.Vientos;
        }

        //---------- Metodos ---------------------------------------------------------
        //______________________________________________________________________________
        private string CompletarDescripClima(int estadoClima)
        {
            List<string> descripciones = new List<string>
            {
                "SOLEADO",
                "PARCIALMENTE NUBLADO",
                "NUBLADO",
                "LLUVIAS",
                "TORMENTAS",
                "NEVADAS"
            };
            return descripciones[estadoClima];
        }
        //______________________________________________________________________________
    }
}
