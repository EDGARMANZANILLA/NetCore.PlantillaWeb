using NetCore.Datos.Repos.Interfaces;
using NetCore.Entidades.DTOs.CPMexicoDTOS.EstadoDTOS;
using NetCore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Datos.CPMexicoDBConsultas
{
    public class DboEstadosConsultas
    {
        private readonly _IRepositoryCPMexicoDb<Estado> _IRepositoryCPMexicoDb;
        private readonly _IRepositoryArdalisCPMexicoDb<Estado> _IRepositoryArdalisCPMexicoDb;
        public DboEstadosConsultas(_IRepositoryCPMexicoDb<Estado> IRepositoryCPMexicoDb, _IRepositoryArdalisCPMexicoDb<Estado> IRepositoryArdalisCPMexicoDb)
        {
            this._IRepositoryCPMexicoDb = IRepositoryCPMexicoDb;
            this._IRepositoryArdalisCPMexicoDb = IRepositoryArdalisCPMexicoDb;
        }

        public async Task<(string, List<EstadosActivosDTO>)> ObtenerEstadosActivos()
        {
            string error = string.Empty;
            List<EstadosActivosDTO> listaEstados = new List<EstadosActivosDTO>();
            try
            {
                listaEstados = _IRepositoryCPMexicoDb.ObtenerTodos()
                                 .Select(x => new EstadosActivosDTO { IdEstado = x.IdEstado, Nombre = x.NombreEstado })
                                 .OrderBy(x => x.IdEstado)
                                 .ToList();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return (error, listaEstados);
        }


        public async Task<(string, EstadosActivosDTO)> ObtenerIdDetalleEstadoActivo(string nombreEstado)
        {
            string error = string.Empty;
            EstadosActivosDTO estado = new EstadosActivosDTO();
            try
            {
                var estados = _IRepositoryCPMexicoDb.ObtenerTodos();
                estado = estados.Where(x => x.NombreEstado == nombreEstado)
                                        .Select(x => new EstadosActivosDTO { IdEstado = x.IdEstado, Nombre = x.NombreEstado }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return (error, estado);
        }


    }
}
