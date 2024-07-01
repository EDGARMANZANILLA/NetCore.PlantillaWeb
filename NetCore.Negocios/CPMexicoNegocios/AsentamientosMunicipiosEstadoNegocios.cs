using NetCore.Datos.CPMexicoDBConsultas;
using NetCore.Datos.Repos.Interfaces;
using NetCore.Entidades;
using NetCore.Entidades.DTOs.CPMexicoDTOS.AsentamientosDTO;
using NetCore.Entidades.DTOs.CPMexicoDTOS.EstadoDTOS;
using NetCore.Entidades.DTOs.CPMexicoDTOS.MunicipiosDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Negocios.CPMexicoNegocios
{
    public class AsentamientosMunicipiosEstadoNegocios
    {
        private readonly DboEstadosConsultas _DboEstadosConsultas;
        private readonly DboMunicipiosConsultas _DboMunicipiosConsultas;
        private readonly _IRepositoryArdalisCPMexicoDb<Asentamiento> _IRepositoryArdalisCPMexicoDb;

        public AsentamientosMunicipiosEstadoNegocios(DboEstadosConsultas DboEstadosConsultas, DboMunicipiosConsultas DboMunicipiosConsultas, _IRepositoryArdalisCPMexicoDb<Asentamiento> IRepositoryArdalisCPMexicoDb)
        {
            _DboEstadosConsultas = DboEstadosConsultas;
            _DboMunicipiosConsultas = DboMunicipiosConsultas;
            _IRepositoryArdalisCPMexicoDb = IRepositoryArdalisCPMexicoDb;
        }


        public async Task<(string, List<EstadosActivosDTO>)> ObtenerEstadosActivos()
        {
            return await _DboEstadosConsultas.ObtenerEstadosActivos();
        }


        public async Task<(string, List<MunicipiosActivosDTO>)> ObtenerMunicipiosDelEstado(string nombreEstadoSeleccionado)
        {
            List<MunicipiosActivosDTO> listaMunicipiosActivos = new List<MunicipiosActivosDTO>();
            (string error, EstadosActivosDTO estado) = await _DboEstadosConsultas.ObtenerIdDetalleEstadoActivo(nombreEstadoSeleccionado);

            if (string.IsNullOrEmpty(error))
            {
                (error, listaMunicipiosActivos) = await _DboMunicipiosConsultas.ObtenerMunicipiosDelEstado(estado.IdEstado);
            }

            return (error, listaMunicipiosActivos);
        }



        public async Task<(string, List<AsentamientosEnMunicipioDTO>)> ObtenerAsentamientosActivosEnMunicipio(int idMunicipio /*, int skipElements, int takeElements*/)
        {
            string error = string.Empty;
            List<AsentamientosEnMunicipioDTO> listaAsentamientoEnMunicipio = new List<AsentamientosEnMunicipioDTO>();
            try
            {
                listaAsentamientoEnMunicipio = await _IRepositoryArdalisCPMexicoDb.ListAsync(new NetCore.Datos.CPMexicoDBConsultas.DboAsentamientosArdalis(idMunicipio /*,  skipElements, takeElements*/));
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return (error, listaAsentamientoEnMunicipio);
        }



    }
}
