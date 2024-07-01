using NetCore.Datos.CPMexicoDBConsultas;
using NetCore.Datos.Repos.Interfaces;
using NetCore.Entidades;
using NetCore.Entidades.DTOs.CPMexicoDTOS.EstadoDTOS;
using NetCore.Entidades.DTOs.CPMexicoDTOS.MunicipiosDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NetCore.Negocios.CPMexicoNegocios
{
    public class MunicipiosNegocios
    {
        private readonly DboEstadosConsultas _DboEstadosConsultas;
        private readonly DboMunicipiosConsultas _DboMunicipiosConsultas;
        public MunicipiosNegocios(DboEstadosConsultas DboEstadosConsultas,  DboMunicipiosConsultas DboMunicipiosConsultas)
        {
            _DboEstadosConsultas = DboEstadosConsultas;
            _DboMunicipiosConsultas = DboMunicipiosConsultas;
        }


        public async Task<(string, List<MunicipiosActivosDTO>)> ObtenerMunicipiosDelEstado(string nombreEstadoSeleccionado)
        {
            List<MunicipiosActivosDTO> listaMunicipiosActivos = new List<MunicipiosActivosDTO> ();
           (string error, EstadosActivosDTO estado) = await _DboEstadosConsultas.ObtenerIdDetalleEstadoActivo(nombreEstadoSeleccionado);

           if (string.IsNullOrEmpty(error)) 
           {
               (error, listaMunicipiosActivos ) = await _DboMunicipiosConsultas.ObtenerMunicipiosDelEstado(estado.IdEstado);
           }

           return (error, listaMunicipiosActivos); 
        }


    }
}
