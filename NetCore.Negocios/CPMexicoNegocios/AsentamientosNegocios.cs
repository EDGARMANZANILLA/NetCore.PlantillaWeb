using NetCore.Datos.CPMexicoDBConsultas;
using NetCore.Datos.Repos.Interfaces;
using NetCore.Entidades;
using NetCore.Entidades.DTOs.CPMexicoDTOS.AsentamientosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Negocios.CPMexicoNegocios
{
    public class AsentamientosNegocios
    {

        private readonly _IRepositoryArdalisCPMexicoDb<Asentamiento> _IRepositoryArdalisCPMexicoDb;
        public AsentamientosNegocios(_IRepositoryArdalisCPMexicoDb<Asentamiento> IRepositoryArdalisCPMexicoDb)
        {
            this._IRepositoryArdalisCPMexicoDb = IRepositoryArdalisCPMexicoDb;
        }


        public async Task<(string, List<AsentamientosEnMunicipioDTO>)> ObtenerAsentamientosActivosEnMunicipio (int idMunicipio /*, int skipElements, int takeElements*/)
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
