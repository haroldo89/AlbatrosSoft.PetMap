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
/// Representa la información de la entidad de dominio Contact.
/// </summary>
[XmlRoot("contact")]
[DataContract(Name="contact")]
[Serializable]
public partial class Contact
{
    public Contact()
    {
        this.AppUser = new HashSet<AppUser>();
    }

	#region Propiedades Primitivas

    [XmlElement]
	[DataMember(Name = "contactId")]
	public int ContactId { get; set; }

    [XmlElement]
	[DataMember(Name = "identification")]
	public string Identification { get; set; }

    [XmlElement]
	[DataMember(Name = "identificationTypeId")]
	public int IdentificationTypeId { get; set; }

    [XmlElement]
	[DataMember(Name = "firstName")]
	public string FirstName { get; set; }

    [XmlElement]
	[DataMember(Name = "lastName")]
	public string LastName { get; set; }

    [XmlElement]
	[DataMember(Name = "email")]
	public string Email { get; set; }

    [XmlElement]
	[DataMember(Name = "phone")]
	public string Phone { get; set; }

    [XmlElement]
	[DataMember(Name = "mobileNumber")]
	public string MobileNumber { get; set; }

    [XmlElement]
	[DataMember(Name = "active")]
	public bool Active { get; set; }

    [XmlElement]
	[DataMember(Name = "contactTypeId")]
	public int ContactTypeId { get; set; }

    [XmlElement]
	[DataMember(Name = "customerId")]
	public int CustomerId { get; set; }

    [XmlElement]
	[DataMember(Name = "externalCode")]
	public string ExternalCode { get; set; }

	#endregion Propiedades Primitivas
	
	#region Propiedades de Navegación

    public virtual ICollection<AppUser> AppUser { get; set; }
    public virtual ContactType ContactType { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual IdentificationType IdentificationType { get; set; }
	
	#endregion Propiedades de Navegación
}
