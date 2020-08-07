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
/// Representa la información de la entidad de dominio IdentificationType.
/// </summary>
[XmlRoot("identificationType")]
[DataContract(Name="identificationType")]
[Serializable]
public partial class IdentificationType
{
    public IdentificationType()
    {
        this.Contact = new HashSet<Contact>();
        this.Customer = new HashSet<Customer>();
    }

	#region Propiedades Primitivas

    [XmlElement]
	[DataMember(Name = "identificationTypeId")]
	public int IdentificationTypeId { get; set; }

    [XmlElement]
	[DataMember(Name = "name")]
	public string Name { get; set; }

    [XmlElement]
	[DataMember(Name = "alias")]
	public string Alias { get; set; }

	#endregion Propiedades Primitivas
	
	#region Propiedades de Navegación

    public virtual ICollection<Contact> Contact { get; set; }
    public virtual ICollection<Customer> Customer { get; set; }
	
	#endregion Propiedades de Navegación
}