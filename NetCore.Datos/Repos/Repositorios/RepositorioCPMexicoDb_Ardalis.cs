using Ardalis.Specification.EntityFrameworkCore;
using NetCore.Datos.CPMexicoDBContext;
using NetCore.Datos.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Datos.Repos.Repositorios
{
    public class RepositorioCPMexicoDb_Ardalis<TEntity> : RepositoryBase<TEntity>, _IRepositoryArdalisCPMexicoDb<TEntity> where TEntity : class
    {
        private readonly CpmexicoContext _CPMexicoDbDbContext;
        public RepositorioCPMexicoDb_Ardalis(CpmexicoContext CpmexicoContext) :base(CpmexicoContext)
        {
            this._CPMexicoDbDbContext = CpmexicoContext;
        }
    }
}
