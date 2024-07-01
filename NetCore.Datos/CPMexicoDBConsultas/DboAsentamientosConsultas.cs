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
    public class DboAsentamientosConsultas
    {
        private readonly _IRepositoryArdalisCPMexicoDb<Estado> _IRepositoryArdalisCPMexicoDb;
        public DboAsentamientosConsultas( _IRepositoryArdalisCPMexicoDb<Estado> IRepositoryArdalisCPMexicoDb)
        {
            this._IRepositoryArdalisCPMexicoDb = IRepositoryArdalisCPMexicoDb;
        }


    }
}
