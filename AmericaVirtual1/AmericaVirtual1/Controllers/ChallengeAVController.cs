using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmericaVirtual1.Data;
using AmericaVirtual1.Models;
using Microsoft.EntityFrameworkCore;

namespace AmericaVirtual1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeAVController : ControllerBase
    {

        private readonly ILogger<ChallengeAVController> _logger;
        private readonly ApiDbContext apiDbContext;

        public ChallengeAVController(ILogger<ChallengeAVController> logger, ApiDbContext apiDbContext)
        {
            _logger = logger;
            this.apiDbContext = apiDbContext;

            // *** Llamadas a los metodos para generar datos de prueba ****
            //Solo habilitar 1 vez si la base de datos no tiene datos

            //CrearPaises();
            //CrearCiudades();
            //GenerarDatosClima();
            //CorregirDatosClima();
            //*************************************************************
        }
        //_______________________________________________________________________________________________
        /// <summary>
        /// Servicio que devuelve todos los paises registrados ordenados por Nombre del Pais
        /// retorna una lista de Entidades Paises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetPaises()
        {
            try
            {
                _logger.LogInformation("Consulta Inicial para cargar Lista de Paises");
                var respuesta = await  apiDbContext.Paises.OfType<Paises>().OrderBy(o => o.NombrePais).ToListAsync();
                if (respuesta?.Count > 0)
                {
                    _logger.LogInformation("Consulta Lista de Paises procesada OK");
                    return Ok(respuesta);
                }
                else
                {
                    if (respuesta != null)
                    {
                        _logger.LogWarning("Consulta Lista de Paises No devuelve resultados");
                        return NoContent();
                    }
                    else 
                    {
                        _logger.LogError("Consulta Lista de Paises devuelve lista = null");
                        return NotFound(); 
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Consulta Lista de Paises Excepcion no controlada");
                _logger.LogCritical(ex.Message);

                return BadRequest();
            }
        }
        //_______________________________________________________________________________________________
        /// <summary>
        /// Servicio que devuelve una Entidad Pais con su respectiva lista de Ciudades Registradas
        /// </summary>
        /// <param name="idPais"></param>
        /// <returns></returns>
        [HttpGet("{idPais}", Name = "GetdByIdPais")]
        public async Task<IActionResult> GetByIdPais(int idPais)
        {
            try
            {
                _logger.LogInformation("Iniciando Consulta de Pais x ID");
                var respuesta =await apiDbContext.Paises.Where(x=> x.Id== idPais).Include(i=> i.ListaCiudades).FirstOrDefaultAsync();
                if (respuesta != null)
                {
                    _logger.LogInformation("Consulta de Pais x ID procesada OK");
                    return Ok(respuesta);
                }
                else 
                {
                    _logger.LogWarning("Consulta de Pais x ID devuelve null");
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Consulta de Pais x Id... Excepcion no controlada");
                _logger.LogCritical(ex.Message);

                return BadRequest();
            }
        }
        //_______________________________________________________________________________________________
        /// <summary>
        /// Servicio que devuelve la lista de ciudades del país consultado con "idPais"
        /// retorna 1 lista de Entidades Ciudades 
        /// </summary>
        /// <param name="idPais"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCiudadesByIdPais/{idPais}")]
        public async Task<IActionResult> GetCiudadesByIdPais(int idPais)
        {
            try
            {
                _logger.LogInformation("Iniciando Consulta de Clima x Ciudad");
                var respuesta = await apiDbContext.Ciudades.Where(x => x.IdPais == idPais).OrderBy(o=> o.NombreCiudad).ToListAsync();
                if (respuesta?.Count > 0)
                {
                    _logger.LogInformation("Consulta Lista de Ciudades procesada OK");
                    return Ok(respuesta);
                }
                else
                {
                    if (respuesta != null)
                    {
                        _logger.LogWarning("Consulta Lista de Ciudades No devuelve resultados");
                        return NoContent();
                    }
                    else
                    {
                        _logger.LogError("Consulta Lista de Ciudades devuelve lista = null");
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Consulta de Ciudades x Id Pais ... Excepcion no controlada");
                _logger.LogCritical(ex.Message);

                return BadRequest();
            }
        }
        //_______________________________________________________________________________________________
        /// <summary>
        /// Servicio que devuelve los datos del clima registrados para la ciudad consulta con "idCiudad"
        /// retorna 1 Entidad Ciudad con las entidades DatosClima relacionadas
        /// </summary>
        /// <param name="idCiudad"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClimaByIdCiudad/{idCiudad}")]
        public async Task<IActionResult> GetClimaByIdCiudad(int idCiudad)
        {
            try
            {
                _logger.LogInformation("Iniciando Consulta de Clima x Ciudad");
                var respuesta = await apiDbContext.Ciudades.Where(x => x.Id == idCiudad).Include(i => i.ListaDatosClima).FirstOrDefaultAsync();
                if (respuesta != null)
                {
                    _logger.LogInformation("Consulta de Clima x Ciudad procesada OK");
                    return Ok(respuesta);
                }
                else 
                {
                    _logger.LogWarning("Consulta de Clima x Ciudad devuelve null");
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Consulta de Clima x Ciudad... Excepcion no controlada");
                _logger.LogCritical(ex.Message);

                return BadRequest();
            }
        }
        //_______________________________________________________________________________________________
        //*************************************************************************
        //*************************************************************************
        /// <summary>
        /// Conjunto de métodos utilizados para generar datos de prueba
        /// NO utilizar !!!!!!!!
        /// </summary>
        #region Metodos para crear datos de Prueba
        private void CrearPaises()
        {
            try
            {
                List<string> listaPaises = new List<string> 
                { 
                    "Uruguay",
                    "Paraguay",
                    "Chile",
                    "Brasil",
                    "Peru",
                    "España",
                    "Italia",
                    "Estados Unidos",
                    "Canada"
                };

                foreach(string dato in listaPaises)
                {
                    Paises pais = new Paises
                    {
                        NombrePais = dato
                    };
                    apiDbContext.Paises.Add(pais);
                    apiDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        //*************************************************************************
        private void CrearCiudades()
        {
            try
            {
                var paises = apiDbContext.Paises.ToList();
                List<Paises> listaPaises = new List<Paises>();
                listaPaises.AddRange(paises);
                foreach(Paises pais in listaPaises)
                {
                    List<string> listaCiudades = new List<string>();
                    switch (pais.Id)
                    {
                        case 2:
                            listaCiudades = new List<string>
                            {
                                "Buenos Aires",
                                "Córdoba",
                                "Rosario",
                                "Mendoza",
                                "San Luis"
                            };
                            GenerarCiudad(pais.Id, listaCiudades);
                            break;
                        //........................................................
                        case 3:
                            listaCiudades = new List<string>
                            {
                                "Montevideo",
                                "Punta del Este",
                                "Rivera"
                            };
                            GenerarCiudad(pais.Id, listaCiudades);
                            break;
                        //........................................................
                        case 4:
                            listaCiudades = new List<string>
                            {
                                "Asunción",
                                "Encarnación"
                            };
                            GenerarCiudad(pais.Id, listaCiudades);
                            break;
                        //........................................................
                        case 5:
                            listaCiudades = new List<string>
                            {
                                "Santiago",
                                "Viña del Mar"
                            };
                            GenerarCiudad(pais.Id, listaCiudades);
                            break;
                        //........................................................
                        case 6:
                            listaCiudades = new List<string>
                            {
                                "Río de Janeiro",
                                "Sao Paulo",
                                "Brasilia",
                                "Porto Alegre"
                            };
                            GenerarCiudad(pais.Id, listaCiudades);
                            break;
                        //........................................................
                        case 7:
                            listaCiudades = new List<string>
                            {
                                "Lima",
                                "Cusco",
                                "Arequipa"
                            };
                            GenerarCiudad(pais.Id, listaCiudades);
                            break;
                        //........................................................
                        case 8:
                            listaCiudades = new List<string>
                            {
                                "Madrid",
                                "Barcelona",
                                "Valencia",
                                "Gijón"
                            };
                            GenerarCiudad(pais.Id, listaCiudades);
                            break;
                        //........................................................
                        case 9:
                            listaCiudades = new List<string>
                            {
                                "Roma",
                                "Milán",
                                "Catania",
                                "Venecia"
                            };
                            GenerarCiudad(pais.Id, listaCiudades);
                            break;
                        //........................................................
                        case 10:
                            listaCiudades = new List<string>
                            {
                                "Washington D.C.",
                                "Chicago",
                                "New York",
                                "Las Vegas"
                            };
                            GenerarCiudad(pais.Id, listaCiudades);
                            break;
                        //........................................................
                        case 11:
                            listaCiudades = new List<string>
                            {
                                "Quebec",
                                "Ottawa",
                                "Montreal",
                                "Vancouver"
                            };
                            GenerarCiudad(pais.Id, listaCiudades);
                            break;
                            //........................................................
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        //*************************************************************************
        private void GenerarCiudad(int idPais, List<string> listaCiudades)
        {
            try
            {
                var pais = apiDbContext.Paises.Where(x => x.Id == idPais).FirstOrDefault();
                foreach (string ciudad in listaCiudades)
                {
                    Ciudades regCiudad = new Ciudades
                    {
                        IdPais = idPais,
                        NombreCiudad = ciudad
                    };

                    pais.ListaCiudades.Add(regCiudad);
                }
                apiDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        //*************************************************************************
        private void GenerarDatosClima()
        {
            try
            {
                var listaCiudades = apiDbContext.Ciudades.ToList();
                if (listaCiudades?.Count > 0)
                {
                    foreach (Ciudades regCiudad in listaCiudades)
                    {
                        List<DatosClima> lstRegClima = new List<DatosClima>();
                        lstRegClima = CrearDatosClima(regCiudad.Id);
                        var ciudad = apiDbContext.Ciudades.Where(x => x.Id == regCiudad.Id).FirstOrDefault();
                        ciudad.ListaDatosClima.AddRange(lstRegClima);
                        apiDbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        //*************************************************************************
        private List<DatosClima> CrearDatosClima(int idCiudad)
        {
            List<DatosClima> lista = new List<DatosClima>();
            try
            {
                Random rnd = new Random();
                int IndiceTipoClima= rnd.Next(1, 6);
                DateTime fecha = DateTime.Now;
                int auxTemperatura = 0;

                DatosClima datos = new DatosClima();
                datos.Fecha = fecha;
                datos.IdCiudad = idCiudad;
                datos.IndicadorClima= IndiceTipoClima;

                if(IndiceTipoClima == 6) { auxTemperatura = rnd.Next(-10, 0); }
                else { auxTemperatura = rnd.Next(5,25); }

                datos.TemperaturaC = auxTemperatura;
                datos.Humedad = rnd.Next(30, 75);
                if(IndiceTipoClima < 4) { datos.Precipitaciones = 0; }
                if (IndiceTipoClima == 4) { datos.Precipitaciones = 30; }
                if (IndiceTipoClima > 4) { datos.Precipitaciones = 80; }
                datos.Vientos = rnd.Next(5, 30);
                lista.Add(datos);
                for (int c = 2; c < 7; c++)
                {
                    datos = new DatosClima();
                    fecha = fecha.AddDays(1);
                    auxTemperatura = rnd.Next(auxTemperatura-5, auxTemperatura +5);
                    IndiceTipoClima = rnd.Next(1, 6);

                    datos.Fecha = fecha;
                    datos.IdCiudad = idCiudad;
                    datos.IndicadorClima = IndiceTipoClima;
                    if (IndiceTipoClima < 4) { datos.Precipitaciones = 0; }
                    if (IndiceTipoClima == 4) { datos.Precipitaciones = 30; }
                    if (IndiceTipoClima > 4) { datos.Precipitaciones = 80; }
                    datos.TemperaturaC = auxTemperatura;
                    datos.Humedad = 0;
                    datos.Vientos = 0;

                    lista.Add(datos);
                }

                return lista;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return lista;
            }
        }
        //*************************************************************************
        private void CorregirDatosClima()
        {
            var datos = apiDbContext.Ciudades.Where(z=> z.Id==107).Include(x=> x.ListaDatosClima).ToList();
            foreach(Ciudades registro in datos)
            {
                foreach(DatosClima clima in registro.ListaDatosClima)
                {
                    if(clima.Id == 3)
                    {
                        Random rnd = new Random();
                        clima.TemperaturaC = rnd.Next(-15, -2);
                        clima.IndicadorClima = 6;
                        apiDbContext.SaveChanges();
                    }
                }
            }
        }
        //*************************************************************************
        #endregion
    }
}
