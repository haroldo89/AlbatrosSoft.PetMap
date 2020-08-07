// ==========================================================================================
// Desarrollado Por		    :   AlbatrosSoft Dev
// Fecha de Creación		:   2016/10/16
// Producto o sistema	    :   AlbatrosSoft.PetMap
// Empresa			        :   AlbatrosSoft
// Proyecto			        :   PetMap10
// ==========================================================================================
// Versión	        Descripción
// 1.0.0.0	        Controla todas las operaciones de persistencia hacia el origen de datos 
//                  de la aplicación (Código generado automáticamente).
//             
// ==========================================================================================
// HISTORIAL DE CAMBIOS:
// ==========================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ---	 -------------	----------------------	----------------------------------------------
// XX	 yyyy/MM/dd	    [Nombre Completo]	    [Razón del cambio realizado] 
// ==========================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using AlbatrosSoft.PetMap.Domain.Dto;
using AlbatrosSoft.PetMap.Data.Repository.Generic;

namespace AlbatrosSoft.PetMap.Data.Repository
{
    /// <summary>
    /// Controla todas las operaciones de persistencia hacia el origen de datos para la entidad AppUserRole.
    /// </summary>
    public partial class AppUserRoleRepository : ObjectRepository<AppUserRole>
    {
    	/// <summary>
        /// Inicializa una nueva instancia del servicio que expone las operaciones de manipulación de datos para la entidad de dominio AppUserRole.
        /// </summary>
    	public AppUserRoleRepository()
            : base(DataContextProvider.PetMapContext)
        { 
    	}
    
    	/// <summary>
        /// Inicializa una nueva instancia del servicio que expone las operaciones de manipulación de datos para la entidad de dominio AppUserRole.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
    	public AppUserRoleRepository(string connectionString)
            : base(connectionString)
        { 
    	}
    	}
}
