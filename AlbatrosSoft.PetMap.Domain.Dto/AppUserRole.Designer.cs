// ==========================================================================================
// Desarrollado Por		    :   AlbatrosSoft Dev
// Fecha de Creación		:   2016/10/16
// Producto o sistema	    :   AlbatrosSoft.PetMap
// Empresa			        :   AlbatrosSoft
// Proyecto			        :   PetMap10
// ==========================================================================================
// Versión	        Descripción
// 1.0.0.0	        Representación en forma de objeto de la información de una entidad de
//                  dominio del sistema (Código generado automáticamente).
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
using System.Runtime.Serialization;
using System.Xml.Serialization;

/// <summary>
/// Representa la información de la entidad de dominio AppUserRole.
/// </summary>
[XmlRoot("appUserRole")]
[DataContract(Name="appUserRole")]
[Serializable]
public partial class AppUserRole
{
    public AppUserRole()
    {
        this.AppUser = new HashSet<AppUser>();
    }

	#region Propiedades Primitivas

    [XmlElement]
	[DataMember(Name = "roleId")]
	public int RoleId { get; set; }

    [XmlElement]
	[DataMember(Name = "roleName")]
	public string RoleName { get; set; }

    [XmlElement]
	[DataMember(Name = "serviceId")]
	public Nullable<int> ServiceId { get; set; }

	#endregion Propiedades Primitivas
	
	#region Propiedades de Navegación

    public virtual ICollection<AppUser> AppUser { get; set; }
	
	#endregion Propiedades de Navegación
}
