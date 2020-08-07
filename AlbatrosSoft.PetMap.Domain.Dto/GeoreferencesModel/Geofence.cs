// ==========================================================================================
// Desarrollado Por		    :   Harold Caicedo
// Fecha de Creación		:   2014/05/27
// Producto o sistema	    :   Wizenz.Navi
// Empresa			        :   Wizenz Technologies
// Proyecto			        :   NAVI30
// Cliente			        :   Wizenz Technologies
// ==========================================================================================
// Versión	        Descripción
// 1.0.0.0	        Representa la información de una geocerca. 
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
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlbatrosSoft.PetMap.Domain.Dto.GeoreferencesModel
{
    /// <summary>
    /// Representa la información de una geocerca. 
    /// </summary>
    [DataContract(Name = "geoFence")]
    public partial class Geofence
    {
        /// <summary>
        /// Nombre
        /// </summary>
        [DataMember(Name = "geoFenceName")]
        public string GeoFenceName { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        [DataMember(Name = "geoFenceDescription")]
        public string GeoFenceDescription { get; set; }
        /// <summary>
        /// Color
        /// </summary>
        [DataMember(Name = "geoFenceColor")]
        public string GeoFenceColor { get; set; }
        /// <summary>
        /// Puntos de geocerca
        /// </summary>
        [DataMember(Name = "geoFencePoints")]
        public List<LocationPoint> GeoFencePoints { get; set; }

    }
}
