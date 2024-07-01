using System;
using System.Collections.Generic;

namespace NetCore.Entidades;

public partial class Asentamiento
{
    public int IdAsentamiento { get; set; }

    public int IdMunicipio { get; set; }

    public string CodigoPostal { get; set; } = null!;

    public string NombreAsentamiento { get; set; } = null!;

    public string TipoAsentamiento { get; set; } = null!;

    public string ClaveTipoAsentamiento { get; set; } = null!;

    public string NombreCiudad { get; set; } = null!;

    public string ClaveCiudad { get; set; } = null!;

    public string IdentificadorAsentamiento { get; set; } = null!;

    public string DescripcionZona { get; set; } = null!;

    public virtual Municipio IdMunicipioNavigation { get; set; } = null!;
}
