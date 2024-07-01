using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Datos.Repos.Interfaces
{
    public interface _IRepositoryArdalisCPMexicoDb<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        //ESTA INTERFACE INPLEMANTA LA UTILERIA DE ARDALIS PARA EMBEBER LOS METODOS DEL REPOSITORIO
        //https://github.com/ardalis/Specification/blob/main/Specification/src/Ardalis.Specification/IRepositoryBase.cs
    }
}
