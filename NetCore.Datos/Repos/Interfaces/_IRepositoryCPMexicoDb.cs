using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Datos.Repos.Interfaces
{
    public interface _IRepositoryCPMexicoDb<TEntity> where TEntity : class
    {
        /**********************************************************************************/
        /**********      CRUD DE OPERACIONES QUE SE DEBEN IMPLEMENTAR        **************/
        /**********************************************************************************/


        /***    INSERCIONES     ***/
        TEntity Agregar(TEntity AgregarEntidad);
        int AgregarMasivo(List<TEntity> ListaEntidadesAgregar);



        /***    LECTURA ***/
        IQueryable<TEntity> ObtenerTodos();
        IQueryable<TEntity> ObtenerPorFiltro(System.Linq.Expressions.Expression<Func<TEntity, bool>> criterio);
        TEntity Obtener(System.Linq.Expressions.Expression<Func<TEntity, bool>> criterio);







        /***    ACTUALIZACIONES     ***/
        TEntity Modificar(TEntity ModificarEntidad);
        int ModificarMasivo(List<TEntity> ModificarEntidades);



        /***    ELIMINACIONES   ***/
        bool Eliminar(TEntity EliminarEntidad);
        int EmilinarMasivo(List<TEntity> EliminarEntidades);


    }
}
