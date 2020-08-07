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
/// Representa la información de la entidad de dominio Dealer.
/// </summary>
[XmlRoot("dealer")]
[DataContract(Name="dealer")]
[Serializable]
public partial class Dealer
{
    public Dealer()
    {
        this.Customer = new HashSet<Customer>();
    }

	#region Propiedades Primitivas

    [XmlElement]
	[DataMember(Name = "dealerId")]
	public int DealerId { get; set; }

    [XmlElement]
	[DataMember(Name = "name")]
	public string Name { get; set; }

    [XmlElement]
	[DataMember(Name = "identification")]
	public string Identification { get; set; }

    [XmlElement]
	[DataMember(Name = "address")]
	public string Address { get; set; }

    [XmlElement]
	[DataMember(Name = "phone")]
	public string Phone { get; set; }

    [XmlElement]
	[DataMember(Name = "mobileNumber")]
	public string MobileNumber { get; set; }

    [XmlElement]
	[DataMember(Name = "email")]
	public string Email { get; set; }

    [XmlElement]
	[DataMember(Name = "principalContactName")]
	public string PrincipalContactName { get; set; }

    [XmlElement]
	[DataMember(Name = "principalContactPhone")]
	public string PrincipalContactPhone { get; set; }

    [XmlElement]
	[DataMember(Name = "active")]
	public bool Active { get; set; }

    [XmlElement]
	[DataMember(Name = "cityId")]
	public Nullable<int> CityId { get; set; }

    [XmlElement]
	[DataMember(Name = "logoIconName")]
	public string LogoIconName { get; set; }

	#endregion Propiedades Primitivas
	
	#region Propiedades de Navegación

    public virtual ICollection<Customer> Customer { get; set; }
	
	#endregion Propiedades de Navegación
}
