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
        /// <summary>
        /// Este proceso envia el request al servicio para recuperar
        /// la lista de paises registrados
        /// espera recibir una lista de Entidades Paises en formato json
        /// y el codigo de respuesta del servicio
        /// deserializa el json 
        /// devuelve un List<Paises> y el codigo de respuesta recibido
        /// </summary>
        /// <returns>
        /// List<Paises>
        /// RespuestaServidor
        /// </returns>
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
        /// <summary>
        /// Este proceso envia el request al servicio para recuperar
        /// la lista de Ciudades registradas del pais referenciado con el parametro idPais
        /// espera recibir una lista de Entidades Ciudades en formato json
        /// y el codigo de respuesta del servicio
        /// deserializa el json 
        /// devuelve un List<Ciudades> y el codigo de respuesta recibido
        /// </summary>
        /// <paramref name="idPais" tipo int/>
        /// <returns>
        /// List<Ciudades>
        /// RespuestaServidor
        /// </returns>
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
        /// <summary>
        /// Este proceso envia el request al servicio para recuperar
        /// una Entidad Ciudades registrada referenciada con el parametro idCiudad
        /// espera recibir una Entidad Ciudades con su Lista de DatosClima correspondiente en formato json
        /// y el codigo de respuesta del servicio
        /// deserializa el json 
        /// devuelve una Entidad Ciudades y el codigo de respuesta recibido
        /// </summary>
        /// <paramref name="idCiudad" tipo int/>
        /// <returns>
        /// Entidad Ciudades con un List<DatosClima> (propiedad ListaDatosClima)
        /// RespuestaServidor
        /// </returns>
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
