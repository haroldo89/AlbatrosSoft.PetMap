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
    /// Controla todas las operaciones de persistencia hacia el origen de datos para la entidad ContactType.
    /// </summary>
    public partial class ContactTypeRepository : ObjectRepository<ContactType>
    {
    	/// <summary>
        /// Inicializa una nueva instancia del servicio que expone las operaciones de manipulación de datos para la entidad de dominio ContactType.
        /// </summary>
    	public ContactTypeRepository()
            : base(DataContextProvider.PetMapContext)
        { 
    	}
    
    	/// <summary>
        /// Inicializa una nueva instancia del servicio que expone las operaciones de manipulación de datos para la entidad de dominio ContactType.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
    	public ContactTypeRepository(string connectionString)
            : base(connectionString)
        { 
    	}
    	}
}
