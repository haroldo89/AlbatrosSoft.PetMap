using AlbatrosSoft.PetMap.Data.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbatrosSoft.PetMap.Domain.Bll
{
    /// <summary>
    /// Establece el comportamiento base de un servicio de dominio que expone operaciones de manipulación de datos sobre una entidad de negocio en particular.
    /// </summary>
    /// <typeparam name="TEntity">Tipo concreto de la entidad de negocio manipulada por el servicio.</typeparam>
    public abstract class DomainService<TEntity> where TEntity : class, new()
    {
        protected ObjectRepository<TEntity> Repository { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de un servicio de manipulación de datos sobre una entidad de negocio en particular.
        /// </summary>
        /// <param name="repository">Repositorio de datos que controla las operaciones de manipulación de datos de la entidad.</param>
        public DomainService(ObjectRepository<TEntity> repository)
        {
            if (repository != null)
            {
                this.Repository = repository;
            }
        }

        /// <summary>
        /// Devuelve una colección con todos los elementos de la entidad de negocio que se encuentran almacenados en el repositorio de datos. 
        /// </summary>
        /// <returns>Conjunto de elementos de la entidad existentes en el origen de datos.</returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.Repository.GetAll();
        }

        /// <summary>
        /// Devuelve el objeto de entidad de negocio que corresponde a un identificador o valor clave específico.
        /// </summary>
        /// <param name="id">Valor clave identificador del objeto.</param>
        /// <returns>Objeto que corresponde al identificador especificado.</returns>
        public virtual TEntity GetById(object id)
        {
            return this.Repository.GetById(id);
        }

        /// <summary>
        /// Permite adicionar de manera segura una instancia de un objeto de negocio al almacen de datos principal del sistema.
        /// </summary>
        /// <param name="entity">Instancia de objeto que representa la entidad a almacenar.</param>
        /// <param name="resultMessage">Mensaje de resultado de la operación (Vacío = Operación Exitosa).</param>
        public virtual void TryAdd(TEntity entity, out string resultMessage)
        {
            resultMessage = string.Empty;
            if (entity != null)
            {
                try
                {
                    resultMessage = this.Add(entity);
                }
                catch (Exception exc)
                {
                    resultMessage = exc.Message;
                }
            }
        }

        /// <summary>
        /// Permite actualizar de manera segura una instancia de un objeto de negocio en el almacen de datos principal del sistema.
        /// </summary>
        /// <param name="entity">Instancia de objeto que representa la entidad a actualizar.</param>
        /// <param name="resultMessage">Mensaje de resultado de la operación (Vacío = Operación Exitosa).</param>
        public virtual void TryUpdate(TEntity entity, out string resultMessage)
        {
            resultMessage = string.Empty;
            if (entity != null)
            {
                try
                {
                    resultMessage = this.Update(entity);
                }
                catch (Exception exc)
                {
                    resultMessage = exc.Message;
                }
            }
        }

        /// <summary>
        /// Permite eliminar de manera segura una instancia de un objeto de negocio del almacen de datos principal del sistema.
        /// </summary>
        /// <param name="entity">Instancia de objeto que representa la entidad a eliminar.</param>
        /// <param name="resultMessage">Mensaje de resultado de la operación (Vacío = Operación Exitosa).</param>
        public virtual void TryDelete(TEntity entity, out string resultMessage)
        {
            resultMessage = string.Empty;
            if (entity != null)
            {
                try
                {
                    resultMessage = this.Remove(entity);
                }
                catch (Exception exc)
                {
                    resultMessage = exc.Message;
                }
            }
        }

        /// <summary>
        /// Ejecuta la operación de adición de una instancia de un objeto de negocio al almacen de datos principal del sistema.
        /// </summary>
        /// <param name="entity">Instancia de objeto que representa la entidad a almacenar.</param>
        /// <returns>Mensaje de resultado de la operación (Vacío = Operación Exitosa).</returns>
        protected string Add(TEntity entity)
        {
            string resultMessage = string.Empty;
            if (entity != null)
            {
                resultMessage = this.Repository.Add(entity);
            }
            return resultMessage;
        }

        /// <summary>
        /// Ejecuta la operación de actualización de una instancia de un objeto de negocio en el almacen de datos principal del sistema.
        /// </summary>
        /// <param name="entity">Instancia de objeto que representa la entidad a actualizar.</param>
        /// <returns>Mensaje de resultado de la operación (Vacío = Operación Exitosa).</returns>
        protected string Update(TEntity entity)
        {
            string resultMessage = string.Empty;
            if (entity != null)
            {
                resultMessage = this.Repository.Update(entity);
            }
            return resultMessage;
        }

        /// <summary>
        /// Ejecuta la operación de eliminación de una instancia de un objeto de negocio del almacen de datos principal del sistema.
        /// </summary>
        /// <param name="entity">Instancia de objeto que representa la entidad a eliminar.</param>
        /// <returns>Mensaje de resultado de la operación (Vacío = Operación Exitosa).</returns>
        protected string Remove(TEntity entity)
        {
            string resultMessage = string.Empty;
            if (entity != null)
            {
                resultMessage = this.Repository.Remove(entity);
            }
            return resultMessage;
        }
    }
}
