using System;
using System.Collections.Generic;

namespace NetCore.Entidades;

public partial class Municipio
{
    public int IdMunicipio { get; set; }

    public int IdEstado { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public string ClaveMunicipio { get; set; } = null!;

    public virtual ICollection<Asentamiento> Asentamientos { get; set; } = new List<Asentamiento>();

    public virtual Estado IdEstadoNavigation { get; set; } = null!;
}
