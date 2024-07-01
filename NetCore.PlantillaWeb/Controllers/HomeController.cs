using Microsoft.AspNetCore.Mvc;
using NetCore.PlantillaWeb.Models;
using System.Diagnostics;
using NetCore.Negocios;
using NetCore.Negocios.CPMexicoNegocios;
using NetCore.Entidades.DTOs.CPMexicoDTOS.EstadoDTOS;
using NetCore.Entidades.DTOs;
using System.Net;
using NetCore.Entidades.DTOs.CPMexicoDTOS.MunicipiosDTOS;
using static System.Runtime.InteropServices.JavaScript.JSType;
using NetCore.Entidades.DTOs.CPMexicoDTOS.AsentamientosDTO;

namespace NetCore.PlantillaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EstadosNegocios _EstadosNegocios;
        private readonly MunicipiosNegocios _MunicipiosNegocios;
        private readonly AsentamientosNegocios _AsentamientosNegocios;

        public HomeController(ILogger<HomeController> logger, EstadosNegocios EstadosNegocios, MunicipiosNegocios MunicipiosNegocios, AsentamientosNegocios AsentamientosNegocios)
        {
            _logger = logger;
            _EstadosNegocios = EstadosNegocios;
            _MunicipiosNegocios = MunicipiosNegocios;
            _AsentamientosNegocios = AsentamientosNegocios;
        }

        public async Task<IActionResult> Index()
        {
            (string error, List<EstadosActivosDTO> listaEstadosActivos) = await _EstadosNegocios.ObtenerEstadosActivos();

            return View(listaEstadosActivos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public async Task<JsonResult> ObtenerMunicipios([FromQuery] string nombreEstadoSeleccionado) 
        {
            (string error, List<MunicipiosActivosDTO> listaMunicipios)  = await _MunicipiosNegocios.ObtenerMunicipiosDelEstado(nombreEstadoSeleccionado);

            Reply reply = new Reply();
            reply.result = listaMunicipios;
            reply.message = error;
            reply.statusCode = !string.IsNullOrEmpty(error) ? HttpStatusCode.NoContent : HttpStatusCode.OK;
            return Json(reply);
        }
        

        [HttpPost]
        public async Task<JsonResult> ObtenerAsentamientos([FromBody]SingleParameterModel<int> idMunicipio) 
        {
            (string error, List<AsentamientosEnMunicipioDTO> listaAsentamientos)  = await _AsentamientosNegocios.ObtenerAsentamientosActivosEnMunicipio(idMunicipio.Value);

            Reply reply = new Reply();
            reply.result = listaAsentamientos;
            reply.message = error;
            reply.statusCode = !string.IsNullOrEmpty(error) ? HttpStatusCode.NoContent : HttpStatusCode.OK;
            return Json(reply);
        }



    }
}
