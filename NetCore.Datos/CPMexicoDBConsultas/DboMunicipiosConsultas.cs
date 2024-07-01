using NetCore.Datos.Repos.Interfaces;
using NetCore.Entidades.DTOs.CPMexicoDTOS.MunicipiosDTOS;
using NetCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Datos.CPMexicoDBConsultas
{
    public class DboMunicipiosConsultas
    {

        private readonly _IRepositoryCPMexicoDb<Municipio> _IRepositoryCPMexicoDb;
        private readonly _IRepositoryArdalisCPMexicoDb<Municipio> _IRepositoryArdalisCPMexicoDb;
        public DboMunicipiosConsultas(_IRepositoryCPMexicoDb<Municipio> IRepositoryCPMexicoDb, _IRepositoryArdalisCPMexicoDb<Municipio> IRepositoryArdalisCPMexicoDb)
        {
            this._IRepositoryCPMexicoDb = IRepositoryCPMexicoDb;
            this._IRepositoryArdalisCPMexicoDb = IRepositoryArdalisCPMexicoDb;
        }


        public async Task<(string, List<MunicipiosActivosDTO>)> ObtenerMunicipiosDelEstado(int idEstado)
        {
            string error = string.Empty;
            List<MunicipiosActivosDTO> municipiosDelEstadoActivos = new List<MunicipiosActivosDTO>();
            try
            {
                municipiosDelEstadoActivos = _IRepositoryCPMexicoDb.ObtenerPorFiltro(x => x.IdEstado == idEstado)
                                            .Select(x => new MunicipiosActivosDTO { IdMunicipio = x.IdMunicipio, NombreMunicipio = x.NombreMunicipio })
                                            .OrderBy(x => x.IdMunicipio)
                                            .ToList();
            }
            catch (Exception e)
            {
                error = e.Message;
                throw;
            }
            return (error, municipiosDelEstadoActivos);
        }

    }
}
