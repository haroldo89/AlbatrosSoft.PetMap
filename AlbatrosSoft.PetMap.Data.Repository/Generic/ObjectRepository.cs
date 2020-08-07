using AlbatrosSoft.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AlbatrosSoft.PetMap.Data.Repository.Generic
{
    /// <summary>
    /// Establece el comportamiento base de un repositorio de objetos que ofrece servicios básicos de lectura y escritura sobre un medio de persistencia.
    /// </summary>
    /// <typeparam name="TEntity">Tipo concreto de objetos a manipular.</typeparam>
    public abstract class ObjectRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Instancia del contexto que establece la comunicación con el origen de datos.
        /// </summary>
        internal DbContext Context;

        /// <summary>
        /// Colección de elementos del tipo de objeto concreto que representa a la entidad de negocio.
        /// </summary>
        internal DbSet<TEntity> EntitySet;

        /// <summary>
        /// Cadena de conexión a la base de datos.
        /// </summary>
        public string DbConnectionString { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de un repositorio de objetos.
        /// </summary>
        /// <param name="context">Instancia del contexto que establece la comunicación con el origen de datos.</param>
        public ObjectRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Contexto de base de datos no puede ser un valor nulo.", "context");
            }
            this.Context = context;
            this.EntitySet = this.Context.Set<TEntity>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de un repositorio de objetos.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public ObjectRepository(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Cadena de conexión a la base de datos no puede ser un valor nulo.", "connectionString");
            }
            this.DbConnectionString = connectionString;
        }

        /// <summary>
        /// Devuelve una colección con todos los elementos de la entidad que se encuentran almacenados en el origen de datos. 
        /// </summary>
        /// <returns>Conjunto de elementos de la entidad existentes en el origen de datos.</returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.EntitySet.AsEnumerable();
        }

        /// <summary>
        /// Devuelve el objeto que corresponde a un identificador o valor clave específico.
        /// </summary>
        /// <param name="id">Valor clave identificador del objeto.</param>
        /// <returns>Objeto que corresponde al identificador especificado.</returns>
        public virtual TEntity GetById(object id)
        {
            var result = this.EntitySet.Find(id);
            return result;
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null/*, string includeProperties = ""*/)
        {
            IEnumerable<TEntity> searchResult = null;
            IQueryable<TEntity> dataSource = this.EntitySet;
            if (filter != null)
            {
                searchResult = dataSource.Where(filter);
            }
            //foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //{
            //    dataSource = dataSource.Include(includeProperty);
            //}
            if (orderBy != null)
            {
                searchResult = orderBy(dataSource).ToList();
            }
            else
            {
                searchResult = dataSource.ToList();
            }
            return searchResult.ToList();
        }

        /// <summary>
        /// Determina si existe algún elemento que cumpla con los criterios especificados dentro de una expresión.
        /// </summary>
        /// <param name="predicate">Expresión de búsqueda o filtrado de elementos.</param>
        /// <returns>true, si se encuentran elementos coincidentes, de lo contrario false.</returns>
        public virtual bool Exists(Func<TEntity, bool> predicate)
        {
            return this.EntitySet.AsEnumerable().Any(predicate);
        }

        /// <summary>
        /// Adiciona el objeto especificado al origen de datos.
        /// </summary>
        /// <param name="entity">Instancia del objeto a guardar.</param>
        /// <returns>Mensaje de resultado de la operación (Vacío = Operación Exitosa).</returns>
        public virtual string Add(TEntity entity)
        {
            string resultMessage = string.Empty;
            if (entity != null)
            {
                this.EntitySet.Add(entity);
                this.SaveChanges();
            }
            return resultMessage;
        }

        /// <summary>
        /// Persiste los cambios realizados al objeto indicado en el almacén de datos.
        /// </summary>
        /// <param name="entity">Instancia del objeto a guardar.</param>
        /// <returns>Mensaje de resultado de la operación (Vacío = Operación Exitosa).</returns>
        public virtual string Update(TEntity entity)
        {
            string resultMessage = string.Empty;
            if (entity != null)
            {
                this.EntitySet.Attach(entity);
                this.Context.Entry(entity).State = EntityState.Modified;
                this.SaveChanges();
            }
            return resultMessage;
        }

        /// <summary>
        /// Ejecuta la operación de eliminación del objeto indicado en el almacén de datos.
        /// </summary>
        /// <param name="entity">Instancia del objeto a eliminar.</param>
        /// <returns>Mensaje de resultado de la operación (Vacío = Operación Exitosa).</returns>
        public virtual string Remove(TEntity entity)
        {
            string resultMessage = string.Empty;
            if (entity != null)
            {
                if (this.Context.Entry(entity).State == EntityState.Detached)
                {
                    this.EntitySet.Attach(entity);
                }
                this.EntitySet.Remove(entity);
                this.SaveChanges();
            }
            return resultMessage;
        }

        /// <summary>
        /// Persite los cambios realizados sobre el grupo de objetos en el repositorio de datos.
        /// </summary>
        public virtual void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}
