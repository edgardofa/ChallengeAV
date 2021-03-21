using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WA_Challenge.Models;
using Newtonsoft.Json;

namespace WA_Challenge.Servicios
{
    public class ServicioDeDatos
    {
        public System.Net.HttpStatusCode RespuestaServidor { get; set; }
        private readonly string urlBase;
        public ServicioDeDatos()
        {
            this.RespuestaServidor = System.Net.HttpStatusCode.Accepted;
            this.urlBase = "https://localhost:44353/ChallengeAV";
        }
        //______________________________________________________________________________________
        public async Task<List<Paises>> ConsultaListaPaises()
        {
            List<Paises> resultado = new List<Paises>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string urlConsult = urlBase;
                    var respuesta =await httpClient.GetAsync(urlConsult);
                    this.RespuestaServidor = respuesta.StatusCode;
                    if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string json = await respuesta.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<List<Paises>>(json); 
                    }
                }

                return resultado;
            }
            catch (Exception )
            {
                this.RespuestaServidor = System.Net.HttpStatusCode.NotImplemented;
                return resultado;
            }

        }
        //______________________________________________________________________________________
        public async Task< List<Ciudades>> ConsultaCiudadesByPais(int idPais)
        {
            List<Ciudades> resultado= new List<Ciudades>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string urlConsult = urlBase + "/GetCiudadesByIdPais/" + idPais;
                    var respuesta = await httpClient.GetAsync(urlConsult);
                    this.RespuestaServidor = respuesta.StatusCode;
                    if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string json = await respuesta.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<List<Ciudades>>(json);
                    }
                }

                return resultado;
            }
            catch (Exception )
            {
                this.RespuestaServidor = System.Net.HttpStatusCode.NotImplemented;
                return resultado;
            }
        }
        //______________________________________________________________________________________
        public async Task<Ciudades> ConsultarClimaByCiudad(int idCiudad)
        {
            Ciudades resultado = new Ciudades();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string urlConsult = urlBase + "/GetClimaByIdCiudad/" + idCiudad;
                    var respuesta = await httpClient.GetAsync(urlConsult);
                    this.RespuestaServidor = respuesta.StatusCode;
                    if (respuesta.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string json = await respuesta.Content.ReadAsStringAsync();
                        resultado = JsonConvert.DeserializeObject<Ciudades>(json);
                    }
                }

                return resultado;
            }
            catch (Exception)
            {
                this.RespuestaServidor = System.Net.HttpStatusCode.NotImplemented;
                return resultado;
            }
        }
        //______________________________________________________________________________________
    }

}
