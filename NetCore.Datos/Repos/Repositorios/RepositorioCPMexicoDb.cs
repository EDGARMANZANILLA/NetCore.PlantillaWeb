using NetCore.Datos.CPMexicoDBContext;
using NetCore.Datos.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Datos.Repos.Repositorios
{
    public class RepositorioCPMexicoDb<TEntity> : _IRepositoryCPMexicoDb<TEntity> where TEntity : class
    {
        private readonly CpmexicoContext _CPMexicoDbDbContext;
        public RepositorioCPMexicoDb(CpmexicoContext CpmexicoContext)
        {
            _CPMexicoDbDbContext = CpmexicoContext;
        }


        /****************************************************************/
        /************             INSERCIONES       *********************/
        /****************************************************************/
        public TEntity Agregar(TEntity AgregarEntidad)
        {
            try
            {
                _CPMexicoDbDbContext.Set<TEntity>().Add(AgregarEntidad);
                _CPMexicoDbDbContext.SaveChanges();
                return AgregarEntidad;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        public int AgregarMasivo(List<TEntity> ListaEntidadesAgregar)
        {
            try
            {
                _CPMexicoDbDbContext.AddRange(ListaEntidadesAgregar);
                _CPMexicoDbDbContext.SaveChanges();
                return ListaEntidadesAgregar.Count();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }



        /****************************************************************/
        /************             LECTURA       *************************/
        /****************************************************************/
        public TEntity Obtener(Expression<Func<TEntity, bool>> criterio)
        {
            return _CPMexicoDbDbContext.Set<TEntity>().FirstOrDefault(criterio);
        }
        public IQueryable<TEntity> ObtenerPorFiltro(Expression<Func<TEntity, bool>> criterio)
        {
            return _CPMexicoDbDbContext.Set<TEntity>().Where(criterio);
        }
        public IQueryable<TEntity> ObtenerTodos()
        {
            return _CPMexicoDbDbContext.Set<TEntity>();
        }




        /****************************************************************/
        /************             ACTUALIZACIONES       *****************/
        /****************************************************************/
        public TEntity Modificar(TEntity ModificarEntidad)
        {
            try
            {
                _CPMexicoDbDbContext.Set<TEntity>().Entry(ModificarEntidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _CPMexicoDbDbContext.SaveChanges();
                return ModificarEntidad;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        public int ModificarMasivo(List<TEntity> ListaModificarEntidades)
        {
            try
            {
                ListaModificarEntidades.ForEach(x => _CPMexicoDbDbContext.Entry(x).State = Microsoft.EntityFrameworkCore.EntityState.Modified);
                //_CPMexicoDbDbContext.Entry(EntidadesAAgregar).State = EntityState.Modified;
                _CPMexicoDbDbContext.SaveChanges();
                return ListaModificarEntidades.Count();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }



        /****************************************************************/
        /************             ELIMINACIONES       *******************/
        /****************************************************************/
        public bool Eliminar(TEntity EliminarEntidad)
        {
            try
            {
                _CPMexicoDbDbContext.Set<TEntity>().Attach(EliminarEntidad);
                _CPMexicoDbDbContext.Set<TEntity>().Remove(EliminarEntidad);
                _CPMexicoDbDbContext.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        public int EmilinarMasivo(List<TEntity> ListaEliminarEntidades)
        {
            try
            {
                _CPMexicoDbDbContext.Set<TEntity>().RemoveRange(ListaEliminarEntidades);
                _CPMexicoDbDbContext.SaveChanges();
                return ListaEliminarEntidades.Count();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }



        public void Dispose()
        {
            _CPMexicoDbDbContext.Dispose();
        }

    }
}
