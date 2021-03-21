using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WA_Challenge.Models;
using WA_Challenge.ViewModels;
using WA_Challenge.Servicios;
using Newtonsoft.Json;

namespace WA_Challenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //_________________________________________________________________________________________________
        //_________________________________________________________________________________________________
        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new IndexViewModel();
            model = await GenerarViewModelInicio();
            return View(model);
        }
        //_________________________________________________________________________________________________
        public IActionResult Privacy()
        {
            return View();
        }
        //_________________________________________________________________________________________________
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //_________________________________________________________________________________________________
        //--------------------------------------------------------------------------------------------------------
        [HttpPost]
        [ActionName("CiudadPorPais")]
        public async Task<ActionResult> GetListCiudadesxPais(int paisId)
        {
            List<Ciudades> respuesta = new List<Ciudades>();
            try
            {
                ServicioDeDatos _servicios = new ServicioDeDatos();
                respuesta = await _servicios.ConsultaCiudadesByPais(paisId);
                if(_servicios.RespuestaServidor!= System.Net.HttpStatusCode.OK)
                {
                    RedirectToAction("Error");
                }
                var json = JsonConvert.SerializeObject(respuesta);
                return new JsonResult(json) ;
            }
            catch (Exception) { return Json(JsonConvert.SerializeObject(respuesta)); }

        }
        //--------------------------------------------------------------------------------------------------------
         
        [HttpPost]
        public async Task<ActionResult> ConsultarClima(string ciudades)
        {
            int id = Convert.ToInt32(ciudades);
            IndexViewModel modeloView = new IndexViewModel();
            if (id == 0) { return View("Index", modeloView); }
            modeloView = await GenerarViewModelDatos(id);
            return View("Index", modeloView);
        }

        //--------------------------------------------------------------------------------------------------------
        #region METODOS
        private async Task<IndexViewModel> GenerarViewModelInicio()
        {
            IndexViewModel modelo = new IndexViewModel();
            try
            {
                modelo.DescripCiudad = string.Empty;
                modelo.DescripPais = string.Empty;
                modelo.ListaCiudades = new List<SelectListItem>();
                //....................................................
                modelo.ListaPaises = new List<SelectListItem>();
                //...................................................
                ServicioDeDatos _servicios = new ServicioDeDatos();
                List<Paises> listaPaises = new List<Paises>();
                listaPaises =await ConsultarPaises();
                if (listaPaises?.Count > 0)
                {
                    foreach(Paises pais in listaPaises)
                    {
                        modelo.ListaPaises.Add(new SelectListItem
                        {
                            Text = pais.NombrePais,
                            Value = pais.Id.ToString()
                        }); ;
                    }
                }
                //....................................................
                modelo.ListaPronosticos = new List<DatosClimaVista>();
                modelo.ReporteDelDia = new DatosClimaVista();
                modelo.Ident_CiudadSelect = string.Empty;
                return modelo;
            }
            catch (Exception) { return modelo; }
        }
        //--------------------------------------------------------------------------------------------------------
        private async Task<List<Paises>> ConsultarPaises()
        {
            List<Paises> respuesta = new List<Paises>();
            try
            {
                ServicioDeDatos _servicios = new ServicioDeDatos();
                respuesta = await _servicios.ConsultaListaPaises();

                if (_servicios.RespuestaServidor != System.Net.HttpStatusCode.OK)
                {
                    RedirectToAction("Error");
                }
                return respuesta;
            }
            catch (Exception)
            {
                return respuesta;
            }
        }
        //--------------------------------------------------------------------------------------------------------
        private async Task<IndexViewModel> GenerarViewModelDatos(int idCiudad)
        {
            ServicioDeDatos _servicios = new ServicioDeDatos();
            IndexViewModel modelo = new IndexViewModel();
            try
            {
                Ciudades respuesta = new Ciudades();
                respuesta = await _servicios.ConsultarClimaByCiudad(idCiudad);
                if(_servicios.RespuestaServidor== System.Net.HttpStatusCode.OK)
                {
                    modelo.Ident_CiudadSelect = respuesta.Id.ToString(); ;
                    modelo.Ident_PaisSelect = respuesta.IdPais;
                    modelo.DescripCiudad = respuesta.NombreCiudad;
                    DatosClima climadelDia = respuesta.ListaDatosClima[0];
                    DatosClimaVista datosclima = new DatosClimaVista(climadelDia);
                    modelo.ReporteDelDia = new DatosClimaVista();
                    modelo.ReporteDelDia = datosclima;
                    modelo.ListaPronosticos = new List<DatosClimaVista>();
                    for (int c = 1; c < 6; c++)
                    {
                        DatosClimaVista pronost = new DatosClimaVista(respuesta.ListaDatosClima[c]);
                        modelo.ListaPronosticos.Add(pronost);
                    }
                }

                modelo.ListaCiudades = new List<SelectListItem>();
                //....................................................
                modelo.ListaPaises = new List<SelectListItem>();
                List<Paises> listaPaises = new List<Paises>();

                _servicios = new ServicioDeDatos();
                listaPaises = await _servicios.ConsultaListaPaises();
                if (listaPaises?.Count > 0)
                {
                    foreach (Paises pais in listaPaises)
                    {
                        if(pais.Id== modelo.Ident_PaisSelect)
                        {
                            modelo.DescripPais = string.IsNullOrEmpty(pais.NombrePais) ? string.Empty : pais.NombrePais;
                        }
                        modelo.ListaPaises.Add(new SelectListItem
                        {
                            Text = pais.NombrePais,
                            Value = pais.Id.ToString()
                        }); ;
                    }
                }
                //....................................................
                return modelo;
            }
            catch (Exception) { return modelo; }
        }
        #endregion
    }
}
