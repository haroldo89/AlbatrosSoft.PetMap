// ==========================================================================================
// Desarrollado Por		    :   AlbatrosSoft Dev
// Fecha de Creación		:   2016/10/16
// Producto o sistema	    :   AlbatrosSoft.PetMap
// Empresa			        :   AlbatrosSoft
// Proyecto			        :   PetMap10
// ==========================================================================================
// Versión	        Descripción
// 1.0.0.0	        Fachada de servicio que expone todas las operaciones de acceso y manipulación  
//                  de datos hacia los repositorios de información del sistema 
//                  (Código generado automáticamente).
//             
// ==========================================================================================
// HISTORIAL DE CAMBIOS:
// ==========================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ---	 -------------	----------------------	----------------------------------------------
// XX	 yyyy/MM/dd	    [Nombre Completo]	    [Razón del cambio realizado] 
// ==========================================================================================

using System;
using System.Linq;
using AlbatrosSoft.PetMap.Domain.Dto;
using AlbatrosSoft.PetMap.Data.Repository;

namespace AlbatrosSoft.PetMap.Domain.Bll
{
    /// <summary>
    /// Fachada de servicio que expone todas las operaciones de acceso y manipulación de datos para la entidad AppUserRole.
    /// </summary>
    public partial class AppUserRoleBll : DomainService<AppUserRole>
    {
    	/// <summary>
    	/// Inicializa una nueva instancia del servicio de manipulación de datos para la entidad AppUserRole.
    	/// </summary>
    	public AppUserRoleBll()
            : base(NaviUnitOfWork.Instance.AppUserRoleRepository)
        { 
    	}
    
    	/// <summary>
        /// Inicializa una nueva instancia del servicio de manipulación de datos para la entidad AppUserRole.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
    	public AppUserRoleBll(string connectionString)
            : base(NaviUnitOfWork.Instance.AppUserRoleRepository)
        {
    		if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Cadena de conexión a la base de datos no puede ser un valor nulo.", "connectionString");
            }
            base.Repository.DbConnectionString = connectionString;
    	}
    }
}
