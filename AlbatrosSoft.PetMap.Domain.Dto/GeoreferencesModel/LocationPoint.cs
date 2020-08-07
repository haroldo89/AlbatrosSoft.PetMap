// ===================================================================================================
// Desarrollado Por		    :   Harold Caicedo.
// Fecha de Creación		:   2014/03/07.
// Producto o sistema	    :   Wizenz.Navi
// Empresa			        :   Wizenz Technologies
// Proyecto			        :   NAVI30
// Cliente			        :   Wizenz Technologies
// ===================================================================================================
// Versión	        Descripción
// 1.0.0.0	        Representa la información de un punto de referencia geográfica.
//             
// ===================================================================================================
// HISTORIAL DE CAMBIOS:
// ===================================================================================================
// Ver.	 Fecha		    Autor					Descripción
// ---	 -------------	----------------------	------------------------------------------------------
// XX	 yyyy/MM/dd	    [Nombre Completo]	    [Razón del cambio realizado] 
// ===================================================================================================

using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Linq;

namespace AlbatrosSoft.PetMap.Domain.Dto.GeoreferencesModel
{
    /// <summary>
    /// Representa la información de un punto de referencia geográfica.
    /// </summary>
    [XmlRoot("locationPoint")]
    [DataContract(Name = "locationPoint")]
    public class LocationPoint
    {
        /// <summary>
        /// Valor de latitud de la coordenada del punto.
        /// </summary>
        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }
        
        /// <summary>
        /// Valor de longitud de la coordenada del punto.
        /// </summary>
        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }
        
        /// <summary>
        /// Nombre o referencia del punto.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        public LocationPoint()
        {

        }

        public LocationPoint(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Construye un punto de referencia geográfica a partir de una cadena de texto en formato SQL Server Spatial Data.
        /// </summary>
        /// <param name="geoText">Cadena de texto que contiene la ubicación geográfica del punto.</param>
        /// <returns>Instancia del punto de referencia.</returns>
        public static LocationPoint Parse(string geoText)
        {
            LocationPoint point = null;
            if (!string.IsNullOrEmpty(geoText))
            {
                var separators = new[] { '(', ')', ' ' };
                var pointData = geoText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (pointData.Any())
                {
                    double latitude = 0, longitude = 0;
                    double.TryParse(pointData[2],NumberStyles.Any, CultureInfo.InvariantCulture, out latitude);
                    double.TryParse(pointData[1],NumberStyles.Any, CultureInfo.InvariantCulture, out longitude);
                    point = new LocationPoint(latitude, longitude);
                }
            }
            return point;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[{0}, {1}]", this.Latitude, this.Longitude);
        }
    }
}
