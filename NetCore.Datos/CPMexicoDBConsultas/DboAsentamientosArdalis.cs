using Ardalis.Specification;
using NetCore.Entidades;
using NetCore.Entidades.DTOs.CPMexicoDTOS.AsentamientosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Datos.CPMexicoDBConsultas
{
    public class DboAsentamientosArdalis : Specification<Asentamiento, AsentamientosEnMunicipioDTO>
    {
        public DboAsentamientosArdalis(int idMunicipio /*, int skipElements, int takeElements*/) 
        {
            Query
                .Select(x => new AsentamientosEnMunicipioDTO
                {
                    NombreAsentamiento = x.NombreAsentamiento,
                    CodigoPostal = x.CodigoPostal,
                    TipoZona = x.TipoAsentamiento,
                    DescripcionZona = x.DescripcionZona
                })
                 .Where(x => x.IdMunicipio == idMunicipio)
                 .OrderByDescending(orderDesc => orderDesc.IdAsentamiento);
                 //.Skip(skipElements)
                 //.Take(takeElements);
        }
    }
}
