using NetCore.Datos.CPMexicoDBConsultas;
using NetCore.Datos.Repos.Interfaces;
using NetCore.Entidades;
using NetCore.Entidades.DTOs.CPMexicoDTOS.EstadoDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NetCore.Negocios.CPMexicoNegocios
{
    public class EstadosNegocios
    {
        private readonly DboEstadosConsultas _DboEstadosConsultas;
        public EstadosNegocios(DboEstadosConsultas DboEstadosConsultas) 
        {
            _DboEstadosConsultas = DboEstadosConsultas;
        }


        public async Task<(string, List<EstadosActivosDTO>)> ObtenerEstadosActivos()
        {
            return await _DboEstadosConsultas.ObtenerEstadosActivos();
        }






    }
}
