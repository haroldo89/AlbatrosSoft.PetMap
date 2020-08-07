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
/// Representa la información de la entidad de dominio AppUser.
/// </summary>
[XmlRoot("appUser")]
[DataContract(Name="appUser")]
[Serializable]
public partial class AppUser
{
	#region Propiedades Primitivas

    [XmlElement]
	[DataMember(Name = "userId")]
	public int UserId { get; set; }

    [XmlElement]
	[DataMember(Name = "username")]
	public string Username { get; set; }

    [XmlElement]
	[DataMember(Name = "password")]
	public string Password { get; set; }

    [XmlElement]
	[DataMember(Name = "creationDate")]
	public System.DateTime CreationDate { get; set; }

    [XmlElement]
	[DataMember(Name = "expirationDate")]
	public System.DateTime ExpirationDate { get; set; }

    [XmlElement]
	[DataMember(Name = "changePasswordDate")]
	public Nullable<System.DateTime> ChangePasswordDate { get; set; }

    [XmlElement]
	[DataMember(Name = "active")]
	public bool Active { get; set; }

    [XmlElement]
	[DataMember(Name = "contactId")]
	public int ContactId { get; set; }

    [XmlElement]
	[DataMember(Name = "roleId")]
	public int RoleId { get; set; }

	#endregion Propiedades Primitivas
	
	#region Propiedades de Navegación

    public virtual AppUserRole AppUserRole { get; set; }
    public virtual Contact Contact { get; set; }
	
	#endregion Propiedades de Navegación
}
