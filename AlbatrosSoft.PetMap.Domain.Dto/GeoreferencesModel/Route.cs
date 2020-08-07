using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace AlbatrosSoft.PetMap.Domain.Dto.GeoreferencesModel
{
    /// <summary>
    /// Definicion de ruta 
    /// </summary>
    [DataContract(Name = "route")]
    public partial class Route
    {
        /// <summary>
        /// Id de la ruta
        /// </summary>
        [DataMember(Name = "routeId")]
        public int RouteId { get; set; }

        /// <summary>
        /// Nombre de la ruta
        /// </summary>
        [DataMember(Name = "routeName")]
        public string RouteName { get; set; }

        /// <summary>
        /// Descripcion de la ruta
        /// </summary>
        [DataMember(Name = "routeDescription")]
        public string RouteDescription { get; set; }

        /// <summary>
        /// Color de la ruta
        /// </summary>
        [DataMember(Name = "routeColor")]
        public string RouteColor { get; set; }

        /// <summary>
        /// Fecha inicial de ruta
        /// </summary>
        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Fecha final de ruta
        /// </summary>
        [DataMember(Name = "endDate")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Longitud de la ruta
        /// </summary>
        [DataMember(Name = "lenght")]
        public double Lenght { get; set; }

        /// <summary>
        /// Puntos de ruta
        /// </summary>
        [DataMember(Name = "routePoints")]
        public List<LocationPoint> RoutePoints { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Route()
        {
            this.RoutePoints = new List<LocationPoint>();
        }

        /// <summary>
        /// Agregar punto a la ruta
        /// </summary>
        /// <param name="point">Punto geografico</param>
        public void AddPoint(LocationPoint point)
        {
            if (point != null)
            {
                LocationPoint lastPoint = null;
                if (this.RoutePoints.Count > 1)
                {
                    //Obtener punto anterior de la ruta
                    lastPoint = this.RoutePoints.Last();
                }
                //Agregar nuevo punto a la ruta.
                this.RoutePoints.Add(point);
                //Existe ultimo punto
                if (lastPoint != null)
                {
                    //Actualizar longitud de la ruta.
                    //this.Lenght += GeoUtils.GetPointsDistance(lastPoint.Latitude, lastPoint.Longitude, point.Latitude, point.Longitude, DistanceUnit.Kilometers); 
                }
            }
        }
    }
}
